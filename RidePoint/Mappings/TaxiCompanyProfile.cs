using AutoMapper;
using RidePoint.Models.Entities;
using RidePoint.Models.TaxiRequest;
using RidePoint.ViewModel.TaxiModels;

namespace RidePoint.Mappings
{
    public class TaxiCompanyProfile : Profile
    {
        public TaxiCompanyProfile()
        {
            CreateMap<TaxiCompany, TaxiCompanyRequest>()
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
                .ReverseMap()
                .ForMember(dest => dest.TaxiCompanyId, opt => opt.Ignore());

            CreateMap<TaxiCompanyRequest, TaxiCompany>()
                .ForMember(dest => dest.TaxiCompanyId, opt => opt.Ignore())
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo));
        }
    }
}