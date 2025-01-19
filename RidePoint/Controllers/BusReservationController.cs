using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RidePoint.Data;
using RidePoint.Models.Entities;
using RidePoint.Models.Enums;
using RidePoint.ViewModel.BusSchedul;
using RidePoint.ViewModel.BusReservation;
using RidePoint.Filters;
using Microsoft.AspNetCore.Authorization;
using AutoMapper.QueryableExtensions;
using RidePoint.Models.Utilities;
using RidePoint.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using RidePoint.Services;

namespace RidePoint.Controllers
{
    [TypeFilter(typeof(BusinessOnlyFilter), Arguments = new object[] { "BusCompany" })]
    [Route("api/BusReservation")]
    public class BusReservationController : Controller
    {
        private readonly IBusReservationService _busReservationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BusReservationController(IBusReservationService busReservationService, IHttpContextAccessor httpContextAccessor)
        {
            _busReservationService = busReservationService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetReservations")]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _busReservationService.GetReservationsAsync();

            if (!reservations.Any())
                return NotFound(ResponseFactory.CreateResponse<object>(
                    ResponseCodes.NotFound,
                    "No reservations found.",
                    null
                ));

            return Ok(ResponseFactory.CreateResponse(
                ResponseCodes.Success,
                "Reservations retrieved successfully.",
                reservations
            ));
        }

        [HttpPost("ConfirmReservation")]
        public async Task<IActionResult> ConfirmReservation([FromBody] EditReservationViewModel model)
        {
            try
            {
                var result = await _busReservationService.ConfirmReservationAsync(model);
                return Ok(ResponseFactory.CreateResponse(
                    ResponseCodes.Success,
                    "Reservation confirmed successfully.",
                    result
                ));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ResponseFactory.CreateResponse<object>(
                    ResponseCodes.NotFound,
                    ex.Message,
                    null
                ));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ResponseFactory.CreateResponse<object>(
                    ResponseCodes.InvalidData,
                    ex.Message,
                    null
                ));
            }
        }

        [HttpPost("CancelReservation")]
        public async Task<IActionResult> CancelReservation([FromBody] EditReservationViewModel model)
        {
            try
            {
                var result = await _busReservationService.CancelReservationAsync(model);
                return Ok(ResponseFactory.CreateResponse(
                    ResponseCodes.Success,
                    "Reservation canceled successfully.",
                    result
                ));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ResponseFactory.CreateResponse<object>(
                    ResponseCodes.NotFound,
                    ex.Message,
                    null
                ));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ResponseFactory.CreateResponse<object>(
                    ResponseCodes.InvalidData,
                    ex.Message,
                    null
                ));
            }
        }
    }
}