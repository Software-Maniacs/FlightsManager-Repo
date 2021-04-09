using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    /// <summary>
    /// The controller for all employees.
    /// </summary>
    public class EmployeeController : Controller
    {
        /// <summary>
        /// The Index method for the controller.
        /// </summary>
        /// <returns>A view of Index.</returns>
        [Authorize(Roles ="Employee, Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
