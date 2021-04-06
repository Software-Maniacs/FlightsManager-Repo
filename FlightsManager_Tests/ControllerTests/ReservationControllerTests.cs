using FlightsManager.Controllers;
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
using NUnit.Framework;

namespace FlightsManager_Tests.ControllerTests
{
    public class ReservationControllerTests
    {
        private ReservationIndexVM _reservationIndex;
        private ReservationController _controller;
        private PassangerCountVM _passangerCount;
        private ApplicationDbContext _db;
        
        [SetUp]
        public void Setup()
        {
            _reservationIndex = new ReservationIndexVM();
            _controller = new ReservationController();
            _db = new ApplicationDbContext();
        }

        [Test]
        public void Index_ReturnsView()
        {
            _reservationIndex = new ReservationIndexVM();
            var result = _controller.Index(_reservationIndex);
            Assert.IsInstanceOf<ViewResult>(result, "Returned result is not of ViewResult type.");
        }
        [Test]
        public void PassangerCount_ReturnsViewForCreate()
        {
            var result = _controller.PassangerCount();
            Assert.IsInstanceOf<ViewResult>(result, "Returned result is not of a ViewResult type.");
        }

        [Test]
        public void PassangerCount_ViewState_Is_Valid_Returns_RedirectToActionResult()
        {
            _passangerCount = new PassangerCountVM
            {
                PassangerCount = 56
            };
            var result = _controller.PassangerCount(_passangerCount);
            Assert.IsInstanceOf<RedirectToActionResult>(result, "Returned result in PassangerCount is not of type RedirectToAction.");
        }

        [Test]
        public void PassangerCount_ViewState_Isnt_Valid_Returns_View()
        {
            _passangerCount = new PassangerCountVM();
            _controller.ModelState.AddModelError("PassangerCount", "Count is null");
            var result = _controller.PassangerCount(_passangerCount);
            Assert.IsInstanceOf<ViewResult>(result, "Returned result in PassangerCount is not of ViewResult type.");
        }

        [Test]
        public void Create_PassangerCountVMMethod_ReturnsIndex()
        {
            _passangerCount = new PassangerCountVM
            {
                PassangerCount = 56
            };
            var result = _controller.Create(_passangerCount);
            Assert.IsInstanceOf<Task<IActionResult>>(result, "Returned result in Create is not of Task<IActionResult> type.");
        }

        [Test]
        public void Create_ViewState_Is_Valid_Returns_CorrectAction()
        {
            ReservationVM[] reservations = new ReservationVM[1];
            List<ReservationVM> temp = new List<ReservationVM>
            {
                new ReservationVM
                {
                    Flight = "23251gea",
                    FirstName = "Andrea",
                    MiddleName = "Laino",
                    LastName = "Barogd",
                    Nationality = "Bulgarian",
                    PIN = "02512",
                    TelephoneNumber = "0885215643",
                    TicketType = "Ordinary",
                    Email = "andrea@gmail.com"
                }
            };
            reservations = temp.ToArray();

            ReservationCreateVM _reservationCreate = new ReservationCreateVM
            {
                Email = "garry@abv.bg",
                IsFirstTime = true,
                Message = "I want to be a cockstar.",
                Flights = this._db.Flight.ToList(),
                Flight = "25152",
                PassangerCount = 1,
                Reservations = reservations
            };
            var result = _controller.Create(_reservationCreate);

            Assert.IsInstanceOf<Task<IActionResult>>(result, "Returned result in Create(ReservationCreateVM method) is not of type Task<IActionResult>.");
        }
        [Test]
        public void Create_ViewState_Isnt_Valid_Returns_CorrectAction()
        {
            ReservationVM[] reservations = new ReservationVM[1];
            List<ReservationVM> temp = new List<ReservationVM>
            {
                new ReservationVM
                {
                    Flight = "23251gea",
                    FirstName = "Andrea",
                    MiddleName = "Laino",
                    LastName = "Barogd",
                    Nationality = "Bulgarian",
                    PIN = "02512",
                    TelephoneNumber = "0885215643",
                    TicketType = "Ordinary",
                    Email = "andrea@gmail.com"
                }
            };
            reservations = temp.ToArray();
            ReservationCreateVM _reservationCreate = new ReservationCreateVM
            {
                IsFirstTime = true,
                Message = "I want to be a cockstar.",
                Flights = this._db.Flight.ToList(),
                Flight = "25152",
                PassangerCount = 1,
                Reservations = reservations
            };
            _controller.ModelState.AddModelError("Email", "Email mustn't be null.");
            var result = _controller.Create(_reservationCreate);

            Assert.IsInstanceOf<Task<IActionResult>>(result, "Returned result in Create(ReservationCreateVM method) is not of type Task<IActionResult>.");
        }
        [Test]
        public void Detail_Returns_ViewResult()
        {
            string id = "315abdsg23";
            var result = _controller.Detail(id);
            Assert.IsInstanceOf<ViewResult>(result, "Returned result in Detail is not of ViewResult type.");
        }
        [Test]
        public void Delete_Returns_CorrectAction()
        {
            string id = "315abdsg23";
            var result = _controller.DeleteAsync(id);
            Assert.IsInstanceOf<Task<IActionResult>>(result, "Returned result in Detail is not of Task<IActionResult> type.");
        }
        [Test]
        public void Confirm_Returns_View()
        {
            string id = "315abdsg23";
            var result = _controller.Confirm(id);
            Assert.IsInstanceOf<ViewResult>(result, "Returned result is not of ViewResult type.");
        }
    }
}
