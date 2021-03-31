using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsManager.Data;
using FlightsManager.Models.Base;
using FlightsManager.Models.Flight;
using FlightsManager.Models.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightsManager.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext db;
        private const int PageSize = 10;

        public FlightController()
        {
            this.db = new ApplicationDbContext();
        }

        public async Task<IActionResult> Index(FlightIndexVM model)
        {
            //TODO: Да се подмени кацането на самолета с времето за което продължава полета
            //TODO: Да се добави списък на резервациите за полета
            //TODO: Да се промени и изгледа

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
                    Landing = f.Landing,
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

        [HttpGet]
        public IActionResult Create()
        {
            FlightCreateVM model = new FlightCreateVM();

            return View(model);
        }

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

        [HttpPost]
        public async Task<IActionResult> Edit(FlightEditVM model)
        {
            if (ModelState.IsValid)
            {
                Flight flight = await db.Flight.FindAsync(model.AirplaneID);

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
                    db.Update<Flight>(flight);
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

            return View(model);
        }

        public IActionResult Detail(string? id)
        {
            List<Reservation> reservations = db.Reservation
                .Where(r => r.FlightID == id)
                .ToList();

            List<ReservationDetailVM> list = new List<ReservationDetailVM>();

            for(int i = 0; i < reservations.Count; i++)
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

        public async Task<IActionResult> Delete(string? id)
        {
            Flight flight = await db.Flight.FindAsync(id);
            db.Flight.Remove(flight);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}