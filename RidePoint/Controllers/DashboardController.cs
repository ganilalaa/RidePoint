﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RidePoint.Models;
using RidePoint.Filters;
using AutoMapper;
using RidePoint.Data;
using RidePoint.Interfaces;
using RidePoint.ViewModel.Bus;
using RidePoint.Models.TaxiRequest;
using RidePoint.Services;
using RidePoint.Models.Enums;
using RidePoint.Models.Utilities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RidePoint.ViewModel.Dashboard;

namespace WebApplication1.Controllers
{
    [ServiceFilter(typeof(AdminBaseFilter))]
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        private readonly IBusCompanyService _busCompanyService;
        private readonly ITaxiCompanyService _taxiCompanyService;
        private readonly IDashboardService _dashboardService;

        public DashboardController(ITaxiCompanyService taxiCompanyService, IBusCompanyService busCompanyService, IDashboardService dashboardService)
        {
            _taxiCompanyService = taxiCompanyService;
            _busCompanyService = busCompanyService;
            _dashboardService = dashboardService;
        }

        public IActionResult Dashboard()
        {
            var model = _dashboardService.GetDashboardData();
            return View(model);
        }

        [HttpGet("Taxi")]
        public IActionResult Taxi()
        {
            var taxiCompanies = _taxiCompanyService.GetAllCompanies();

            var viewModel = new ManageTaxiCompanyRequest
            {
                TaxiCompanies = taxiCompanies
            };

            return View(viewModel);
        }

        [HttpGet("Bus")]
        public IActionResult Bus()
        {
            var busCompanies = _busCompanyService.GetAllBusCompanies();
            var viewModel = new ManageBusCompanyViewModel
            {
                BusCompanies = busCompanies
            };

            return View(viewModel);
        }
    }
}