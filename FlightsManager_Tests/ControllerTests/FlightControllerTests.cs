using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
using FlightsManager.Data;
using FlightsManager.Controllers;
using FlightsManager.Models.Flight;
using FlightsManager.Models.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlightManager_Tests.ControllerTests
{
    public class FlightControllerTests
    {
        private FlightIndexVM _flightIndex;
        private FlightController _controller;
        private FlightCreateVM _flight;
        [SetUp]
        public void Setup()
        {
            _flightIndex = new FlightIndexVM();
            _controller = new FlightController();
        }

        [OneTimeTearDown]
        public void DeleteLeftOvers()
        {
            using (var db = new ApplicationDbContext())
            {
                List<Flight> temp = db.Flight.Where(f => f.AirplaneType.Equals("Beautiful")).ToList();
                if (temp != null)
                {
                    db.Flight.RemoveRange(temp);
                    db.SaveChanges();
                }
            }
        }
        [Test]
        public void Index_ReturnsCorrectAction()
        {
            var result = _controller.Index(_flightIndex);
            Assert.IsInstanceOf<Task<IActionResult>>(result, "Returned index is not of a IActionResult type.");
        }

        [Test]
        public void Create_ViewState_ReturnsViewForCreate()
        {
            var result = _controller.Create();
            Assert.IsInstanceOf<ViewResult>(result, "Returned create view is not of a ViewResult type.");
        }

        [Test]
        public void Create_Is_Valid_Returns_Index()
        {
            _flight = new FlightCreateVM
            {
                AirplaneType = "Beautiful",
                BusinessClassCapacity = 23,
                Capacity = 256,
                DestinationFrom = "Sofia",
                DestinationTo = "Aytos",
                PilotName = "Anderson",
                TakesOff = DateTime.Now,
                Landing = DateTime.Now
            };
            var result = _controller.Create(_flight);
            Assert.IsInstanceOf<Task<IActionResult>>(result, "Return value is not of IActionResult type.");
        }
        [Test]
        public void Create_Isnt_Valid_ReturnsCorrectAction()
        {
            _flight = new FlightCreateVM
            {
                AirplaneType = "Beautiful",
                BusinessClassCapacity = 23,
                DestinationFrom = "Sofia",
                DestinationTo = "Aytos",
                PilotName = "Anderson"
            };
            _controller.ModelState.AddModelError("Capacity", "Must have capacity");
            
            var result = _controller.Create(_flight);
            Assert.IsInstanceOf<Task<IActionResult>>(result, "Returned result isn't of IActionResult type.");
        }
        [Test]
        public void Edit_ViewState_Returns_CorrectAction()
        {
            string id = "232-gsbsd";
            var result = _controller.Edit(id);
            id = null;
            var result2 = _controller.Edit(id);
            Assert.IsInstanceOf<Task<IActionResult>>(result, "Returned first result is not of IActionResult type.");
            Assert.IsInstanceOf<Task<IActionResult>>(result2, "Returned second result is not of IActionResult type.");
        }
        [Test]
        public void Detail_Returns_ViewResult()
        {
            string id = "232-gsbsd";
            var result = _controller.Detail(id);
            Assert.IsInstanceOf<ViewResult>(result, "Returned result is not of ViewResult type.");

        }
        [Test]
        public void Delete_Returns_Index()
        {
            string id = "232-gsbsd";
            var result = _controller.Delete(id);
            Assert.IsInstanceOf<Task<IActionResult>>(result, "Returned result is not of IActionResult type.");
        }

    }
}
