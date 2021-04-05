using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FlightsManager.Data;
using FlightsManager.Controllers;
using FlightsManager.Models.Flight;
using FlightsManager.Models.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlightManager_Tests.ControllerTests
{
    [TestFixture]
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
        [Test]
        public void Index_ReturnsViewForIndex()
        {
            var result = _controller.Index(_flightIndex);
            Assert.IsInstanceOf<ViewResult>(result, "Returned index is not of a ViewResult type.");
        }

        [Test]
        public void Create_ViewState_ReturnsViewForCreate()
        {
            var result = _controller.Create();
            Assert.IsInstanceOf<ViewResult>(result, "Returned create view is not of a ViewResult type.");
        }

        [Test]
        public void Create_Is_Valid_Contains_Correct_Action()
        {
            _flight = new FlightCreateVM
            {
                AirplaneType = "Beautiful",
                BusinessClassCapacity = 23,
                Capacity = 256,
                DestinationFrom = "Sofia",
                DestinationTo = "Aytos",
                PilotName = "Anderson"
            };
            var result = _controller.Create(_flight);
            Assert.IsInstanceOf<Task<RedirectToActionResult>>(result, "Return value is not of RedirectToActionResult type.");

        }
        [Test]
        public void Create_Isnt_Valid_ReturnsView()
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
            Assert.IsInstanceOf<Task<ViewResult>>(result, "Returned result isn't of ViewResult type.");
        }
        [Test]
        public void Edit_ViewState_Returns_NotFound()
        {
            string id = "232-gsbsd";
            var result = _controller.Edit(id);
            id = null;
            var result2 = _controller.Edit(id);
            Assert.IsInstanceOf<Task<NotFoundResult>>(result, "Returned second result is not of NotFound type.");
            Assert.IsInstanceOf<Task<NotFoundResult>>(result2, "Returned second result is not of NotFound type.");
        }
        [Test]
        public void Detail_Returns_ViewResult()
        {
            string id = "232-gsbsd";
            var result = _controller.Detail(id);
            Assert.IsInstanceOf<ViewResult>(result, "Returned result is not of ViewResult type.");

        }
        [Test]
        public void Delete_Returns_RedirectToActionResult()
        {
            string id = "232-gsbsd";
            var result = _controller.Delete(id);
            Assert.IsInstanceOf<Task<RedirectToActionResult>>(result, "Returned result is not of RedirectToAction type.");
        }

    }
}
