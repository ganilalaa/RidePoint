using RidePoint.Models.Enums;

namespace RidePoint.Models.BusRequests
{
    public class EditReservationRequest
    {
        /// <summary>
        /// Unique identifier for the reservation to be edited.
        /// </summary>
        public int ReservationId { get; set; }

        /// <summary>
        /// New status for the reservation.
        /// </summary>
        public BusReservationStatus Status { get; set; }

        /// <summary>
        /// The time at which the reservation was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}