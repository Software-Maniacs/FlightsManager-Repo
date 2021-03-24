using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    public class EmployeeController : Controller
    {
        [Authorize(Roles ="Employee, Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
