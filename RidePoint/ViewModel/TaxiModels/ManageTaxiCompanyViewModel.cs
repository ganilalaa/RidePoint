using RidePoint.ViewModel.TaxiModels;
using System.Collections.Generic;

namespace RidePoint.ViewModel.Taxi
{
    public class ManageTaxiCompanyViewModel
    {
        public List<TaxiCompanyViewModel> TaxiCompanies { get; set; } = new List<TaxiCompanyViewModel>();
    }
}
