using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsManager.Data;
using FlightsManager.Models.Base;
using FlightsManager.Models.Flight;
using FlightsManager.Models.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightsManager.Controllers
{
    /// <summary>
    /// The controller for all flights.
    /// </summary>
    [Authorize(Roles = "Employee, Admin")]
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext db;
        private const int PageSize = 10;

        /// <summary>
        /// The default constructor of the controller.
        /// </summary>
        /// <remarks>
        /// When initiated, the controller connects to the database.
        /// </remarks>
        public FlightController()
        {
            this.db = new ApplicationDbContext();
        }

        /// <summary>
        /// The Index method.
        /// </summary>
        /// <param name="model">The Index view.</param>
        /// <returns>A view of all flights.</returns>
        public async Task<IActionResult> Index(FlightIndexVM model)
        {
            model.Pager ??= new PagerVM();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<FlightVM> items = await db.Flight
                .Skip((model.Pager.CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .Select(f => new FlightVM()
                {
                    AirplaneID = f.AirplaneID,
                    DestinationFrom = f.DestinationFrom,
                    DestinationTo = f.DestinationTo,
                    TakesOff = f.TakesOff,
                    ContiniusFlight = f.Landing.Subtract(f.TakesOff),
                    AirplaneType = f.AirplaneType,
                    PilotName = f.PilotName,
                    Capacity = f.Capacity,
                    BusinessClassCapacity = f.BusinessClassCapacity,
                    Reservations = null
                }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await db.Flight.CountAsync() / (double)PageSize);

            return View(model);
        }

        /// <summary>
        /// Method that returns a view where a flight can be created.
        /// </summary>
        /// <returns>The said view.</returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            FlightCreateVM model = new FlightCreateVM();

            return View(model);
        }

        /// <summary>
        /// Method through which a flight is created.
        /// </summary>
        /// <param name="model">The view where the info is stored.</param>
        /// <returns>If the info is valid, the method redirects to Index. If not, it returns to the same view.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(FlightCreateVM model)
        {
            Guid id = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                Flight flight = new Flight
                {
                    AirplaneID = id.ToString(),
                    DestinationFrom = model.DestinationFrom,
                    DestinationTo = model.DestinationTo,
                    TakesOff = model.TakesOff,
                    Landing = model.Landing,
                    AirplaneType = model.AirplaneType,
                    PilotName = model.PilotName,
                    Capacity = model.Capacity,
                    BusinessClassCapacity = model.BusinessClassCapacity,
                    Reservations = null
                };

                db.Add<Flight>(flight);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        /// <summary>
        /// Method that returns the view where a flight can be edited through.
        /// </summary>
        /// <param name="id">The ID of the requested flight.</param>
        /// <returns>If successful, the method returns the view. If the id is not correct or if the flight is not found - a NotFound result.</returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight model = await db.Flight.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            FlightEditVM flight = new FlightEditVM
            {
                AirplaneID = model.AirplaneID,
                DestinationFrom = model.DestinationFrom,
                DestinationTo = model.DestinationTo,
                TakesOff = model.TakesOff,
                Landing = model.Landing,
                AirplaneType = model.AirplaneType,
                PilotName = model.PilotName,
                Capacity = model.Capacity,
                BusinessClassCapacity = model.BusinessClassCapacity,
                Reservations = model.Reservations
            };

            return View(flight);
        }

        /// <summary>
        /// Method that edits a flight.
        /// </summary>
        /// <param name="model">The view containing the new info.</param>
        /// <returns>If successful, the method redirects back to Index. If the info isn't valid, it returns back the view. If the flight is not found - a NotFound result.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(FlightEditVM model)
        {
            int minOrdinaryTickets = 0;
            int minBusinessTickets = 0;

            List<Reservation> reservations = db.Reservation
                .Where(r => r.FlightID == model.AirplaneID)
                .ToList();
            List<ApplicationUser> passangers = new List<ApplicationUser>();

            foreach (var reservation in reservations)
            {
                List<ApplicationUser> passangersLoop = db.ApplicationUser.Where(p => p.ReservationID == reservation.ID).ToList();
                foreach (var passanger in passangersLoop)
                {
                    passangers.Add(passanger);
                    if (passanger.TicketType == "Ordinary")
                    {
                        minOrdinaryTickets++;
                    }
                    else
                    {
                        minBusinessTickets++;
                    }
                }
            }

            if (minBusinessTickets > model.BusinessClassCapacity || minOrdinaryTickets > model.Capacity)
            {
                model.IsFirstTime = false;
                model.Message = $"You have {minOrdinaryTickets} reserved ordinary tickets and {minBusinessTickets} reserved business tickets. Please do not edit ordinary and business tickets less than that!";

                return View(model);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Flight flight = await db.Flight.FindAsync(model.AirplaneID);

                    flight.AirplaneID = flight.AirplaneID;
                    flight.DestinationFrom = model.DestinationFrom;
                    flight.DestinationTo = model.DestinationTo;
                    flight.TakesOff = model.TakesOff;
                    flight.Landing = model.Landing;
                    flight.AirplaneType = model.AirplaneType;
                    flight.PilotName = model.PilotName;
                    flight.Capacity = model.Capacity;
                    flight.BusinessClassCapacity = model.BusinessClassCapacity;
                    flight.Reservations = model.Reservations;

                    try
                    {
                        db.Update(flight);
                        reservations.ForEach(r => db.Add(r));
                        passangers.ForEach(p => db.Add(p));
                        await db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        bool isExist = db.Flight.Any(f => f.AirplaneID == flight.AirplaneID);

                        if (!isExist)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        /// <summary>
        /// Method that returns a view of all the flight's reservations.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The said view.</returns>
        public IActionResult Detail(string? id)
        {
            List<Reservation> reservations = db.Reservation
                .Where(r => r.FlightID == id)
                .ToList();

            List<ReservationDetailVM> list = new List<ReservationDetailVM>();

            for (int i = 0; i < reservations.Count; i++)
            {
                ReservationDetailVM reservationDetail = new ReservationDetailVM()
                {
                    Items = db.ApplicationUser
                        .Where(p => p.ReservationID == reservations[i].ID)
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

                list.Add(reservationDetail);
            }

            FlightDetailVM model = new FlightDetailVM()
            {
                Items = list
            };

            return View(model);
        }

        /// <summary>
        /// Method through which a flight is deleted.
        /// </summary>
        /// <param name="id">The ID of the requested flight.</param>
        /// <returns>Redirects back to Index.</returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string? id)
        {
            Flight flight = await db.Flight.FindAsync(id);
            db.Flight.Remove(flight);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}