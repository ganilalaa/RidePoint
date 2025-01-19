using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RidePoint.Models;

namespace RidePoint.Controllers
{
    public class BusController : Controller
    {
        public IActionResult BusSchedules()
        {
            return View();
        }
    }
}