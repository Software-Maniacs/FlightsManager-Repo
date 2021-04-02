using FlightsManager.Data;
using FlightsManager.Models.Base;
using FlightsManager.Models.Flight;
using FlightsManager.Models.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext db;
        private const int PageSize = 5;

        public ReservationController()
        {
            this.db = new ApplicationDbContext();
        }

        public IActionResult Index(ReservationIndexVM model)
        {
            model.Pager ??= new PagerVM();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<Reservation> list = db.Reservation.ToList();
            List<ReservationIndexDetailVM> items = new List<ReservationIndexDetailVM>();

            for (int i = 0; i < list.Count; i++)
            {
                string id = list[i].ID;
                string flight = db.Flight.Find(list[i].FlightID).ToString();
                int passangerCount = db.ApplicationUser
                    .Where(p => p.ReservationID == id)
                    .Count();
                bool isConfirm = db.ApplicationUser
                    .Where(p => p.ReservationID == id)
                    .FirstOrDefault()
                    .EmailConfirmed;

                items.Add(new ReservationIndexDetailVM()
                {
                    ID = id,
                    Flight = flight,
                    PassangerCount = passangerCount,
                    IsConfirm = isConfirm
                });
            }

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(list.Count / (double)PageSize);

            return View(model);
        }

        [HttpGet]
        public IActionResult PassangerCount()
        {
            PassangerCountVM model = new PassangerCountVM();

            return View(model);
        }

        [HttpPost]
        public IActionResult PassangerCount(PassangerCountVM model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Create", model);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(PassangerCountVM passangerCountVM)
        {
            ReservationCreateVM model = new ReservationCreateVM()
            {
                Flights = await this.db.Flight.ToListAsync(),
                PassangerCount = passangerCountVM.PassangerCount,
                Reservations = new ReservationVM[passangerCountVM.PassangerCount]
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateVM model)
        {
            int businessTickets = 0;
            int ordinaryTickets = 0;

            for (int i = 0; i < model.Reservations.Length; i++)
            {
                if (model.Reservations[i].TicketType == "Ordinary")
                {
                    ordinaryTickets++;
                }
                else
                {
                    businessTickets++;
                }
            }

            List<Reservation> reservations = db.Reservation.Where(r => r.FlightID == model.Flight).ToList();

            int reservationBusinessTickets = 0;
            int reservationOrdinaryTickets = 0;

            for(int i = 0; i < reservations.Count; i++)
            {
                reservationOrdinaryTickets += db.ApplicationUser
                    .Where(p => p.ReservationID == reservations[i].ID)
                    .Where(p => p.TicketType == "Ordinary")
                    .Count();

                reservationBusinessTickets += db.ApplicationUser
                    .Where(p => p.ReservationID == reservations[i].ID)
                    .Where(p => p.TicketType == "Business")
                    .Count();
            }

            Flight flight = db.Flight.Find(model.Flight);
            int freeBusinessTickets = flight.BusinessClassCapacity - reservationBusinessTickets;
            int freeOrdinaryTickets = flight.Capacity - reservationOrdinaryTickets;

            if (businessTickets > freeBusinessTickets || ordinaryTickets > freeOrdinaryTickets)
            {
                model.IsFirstTime = false;
                model.Flights = db.Flight.ToList();

                model.PassangerCount = model.Reservations.Length;
                model.Message = $"We cannot accept this reservation. For this flight there are {freeBusinessTickets} business tickets and {freeOrdinaryTickets} ordinary tickets free. Please change the ticket types to make a reservation.";
                return View(model);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    string reservationID = Guid.NewGuid().ToString();

                    for (int i = 0; i < model.Reservations.Length; i++)
                    {
                        ApplicationUser passanger = new ApplicationUser()
                        {
                            ReservationID = reservationID,
                            FirstName = model.Reservations[i].FirstName,
                            MiddleName = model.Reservations[i].MiddleName,
                            LastName = model.Reservations[i].LastName,
                            Email = model.Email,
                            Nationality = model.Reservations[i].Nationality,
                            PhoneNumber = model.Reservations[i].TelephoneNumber,
                            TicketType = model.Reservations[i].TicketType,
                            UserPIN = model.Reservations[i].PIN
                        };

                        db.Add<ApplicationUser>(passanger);
                    }

                    Reservation reservation = new Reservation()
                    {
                        ID = reservationID,
                        FlightID = model.Flight
                    };

                    db.Add<Reservation>(reservation);
                    await db.SaveChangesAsync();

                    BuildEmailTemplate(reservationID);

                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        public IActionResult Detail(string? id)
        {
            ReservationDetailVM model = new ReservationDetailVM()
            {
                Items = db.ApplicationUser
                .Where(p => p.ReservationID == id)
                .Select(p => new ReservationVM()
                {
                    FirstName = p.FirstName,
                    MiddleName = p.MiddleName,
                    LastName = p.LastName,
                    Email = p.Email,
                    Nationality = p.Nationality,
                    PIN = p.UserPIN,
                    TelephoneNumber = p.PhoneNumber,
                    TicketType = p.TicketType
                }).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> DeleteAsync(string? id)
        {
            List<ApplicationUser> list = db.ApplicationUser
                .Where(p => p.ReservationID == id)
                .ToList();

            if (list[0].EmailConfirmed)
            {
                throw new Exception();
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    db.ApplicationUser.Remove(list[i]);
                }
            }

            Reservation reservation = db.Reservation.Find(id);
            db.Remove(reservation);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public void BuildEmailTemplate(string reservationID)
        {
            List<ApplicationUser> list = db.ApplicationUser.Where(u => u.ReservationID == reservationID).ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("You make reservation for:<br/>");


            for (int i = 0; i < list.Count; i++)
            {
                sb.Append($"{list[i].FirstName} {list[i].MiddleName} {list[i].LastName}<br/>");
            }

            int bussinesTickets = list.Where(p => p.TicketType == "Business").Count();
            int ordinaryTickets = list.Where(p => p.TicketType == "Ordinary").Count();

            string url = "http://localhost:59540" + "/Reservation/EmailConfirm?id=" + list[0].Id;

            sb.Append("Total:<br/>")
                .Append($"Business Tickets: {bussinesTickets}<br/>")
                .Append($"Ordinary Tickets: {ordinaryTickets}<br/>")
                .Append("Please click <a href=" + url + ">Here</a> to confirm a reservation.");

            string body = sb.ToString();

            BuildEmailTemplate("Your Reservation Is Successfully Confirm", body, list[0].Email);
        }

        public static void BuildEmailTemplate(string subjectText, string bodyText, string emailTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "managerflight31@gmail.com";
            to = emailTo;
            bcc = "";
            cc = "";
            subject = subjectText;
            body = bodyText;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));

            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }

            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }

        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(
                "managerflight31@gmail.com", "flightmanager");

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Confirm(string id)
        {
            ViewBag.ID = id;
            return View();
        }

        public JsonResult EmailConfirm(string id)
        {
            ApplicationUser user = db.ApplicationUser.Find(id);
            List<ApplicationUser> list = db.ApplicationUser.Where(p => p.ReservationID == user.ReservationID).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                list[i].EmailConfirmed = true;
                db.ApplicationUser.Update(list[i]);
            }

            db.SaveChangesAsync();

            string msg = "Your Reservation Is Confirm!";
            return Json(msg);
        }
    }
}
