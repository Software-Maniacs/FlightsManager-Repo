using FlightsManager.Data;
using FlightsManager.Models.Base;
using FlightsManager.Models.Flight;
using FlightsManager.Models.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IActionResult> Index(ReservationIndexVM model)
        {
            model.Pager ??= new PagerVM();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<Reservation> list = db.Reservation.ToList();
            List<ReservationIndexDetailVM> items = new List<ReservationIndexDetailVM>();

            for(int i = 0; i < list.Count; i++)
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
            return RedirectToAction("Create", model);
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
                        Email = model.Reservations[i].Email,
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

                return RedirectToAction(nameof(Index));
            }

            return View(model);
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
                for(int i = 0; i < list.Count; i++)
                {
                    db.ApplicationUser.Remove(list[i]);
                }
            }

            Reservation reservation = db.Reservation.Find(id);
            db.Remove(reservation);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
