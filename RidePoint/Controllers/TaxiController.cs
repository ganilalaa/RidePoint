using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RidePoint.Models;
using RidePoint.Filters;
using Microsoft.AspNetCore.Authorization;

namespace RidePoint.Controllers
{

    [AllowAnonymous]
    public class TaxiController : Controller
    {
        public IActionResult TaxiBooking()
        {
            return View();
        }
        public IActionResult TaxiReservation()
        {
            return View();
        }
    }
}