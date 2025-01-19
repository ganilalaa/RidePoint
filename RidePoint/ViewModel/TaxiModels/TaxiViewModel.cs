using System.Globalization;
using RidePoint.Models.Enums; 

namespace RidePoint.ViewModel.Taxi
{
    public class TaxiViewModel
    {
        public int TaxiId { get; set; }
        public string LicensePlate { get; set; }
        public string DriverName { get; set; } 
        public int? DriverId { get; set; }
        public int TaxiCompanyId { get; set; }
        public string CompanyName { get; set; }
        public TaxiStatus Status { get; set; } 
    }
}