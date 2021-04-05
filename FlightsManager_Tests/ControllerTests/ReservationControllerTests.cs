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
        private ReservationCreateVM _reservationCreate;
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
        public void Create_PassangerCountVMMethod_ReturnsView()
        {
            _passangerCount = new PassangerCountVM
            {
                PassangerCount = 56
            };
            var result = _controller.Create(_passangerCount);
            Assert.IsInstanceOf<Task<ViewResult>>(result, "Returned result in Create is not of ViewResult type.");
        }

        [Test]
        public void Create_ViewState_Is_Valid_Returns_RedirectToActionResult()
        {
            _passangerCount = new PassangerCountVM { PassangerCount = 6 };
            ReservationCreateVM _reservationCreate = new ReservationCreateVM
            {
                Flights = this._db.Flight.ToList(),
                PassangerCount = _passangerCount.PassangerCount,
                Reservations = new ReservationVM[_passangerCount.PassangerCount]
            };
            var result = _controller.Create(_reservationCreate);

            Assert.IsInstanceOf<Task<RedirectToActionResult>>(result, "Returned result in Create(ReservationCreateVM method) is not of type Task<RedirectToActionResult>.");
        }
        [Test]
        public void Create_ViewState_Isnt_Valid_Returns_ViewResult()
        {
            _passangerCount = new PassangerCountVM { PassangerCount = 6 };
            ReservationCreateVM _reservationCreate = new ReservationCreateVM
            {
                Reservations = new ReservationVM[_passangerCount.PassangerCount],
                PassangerCount = 6
            };
            _controller.ModelState.AddModelError("Flights", "Flights mustn't be null.");
            var result = _controller.Create(_reservationCreate);

            Assert.IsInstanceOf<Task<ViewResult>>(result, "Returned result in Create(ReservationCreateVM method) is not of type Task<ViewResult>.");
        }
        [Test]
        public void Detail_Returns_ViewResult()
        {
            string id = "315abdsg23";
            var result = _controller.Detail(id);
            Assert.IsInstanceOf<ViewResult>(result, "Returned result in Detail is not of ViewResult type.");
        }
        [Test]
        public void Delete_Returns_RedirectToAction()
        {
            string id = "315abdsg23";
            var result = _controller.DeleteAsync(id);
            Assert.IsInstanceOf<Task<RedirectToActionResult>>(result, "Returned result in Detail is not of RedirectToAction type.");
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
