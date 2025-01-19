﻿using AutoMapper;
using RidePoint.Models.Entities;
using RidePoint.ViewModel.Bus;

namespace RidePoint.Mappings
{
    public class BusProfile : Profile
    {
        public BusProfile()
        {
            CreateMap<Buses, AddBusViewModel>()
                .ForMember(dest => dest.BusCompanyId, opt => opt.MapFrom(src => src.BusCompanyId))
                .ReverseMap()
                .ForMember(dest => dest.BusId, opt => opt.Ignore())           
                .ForMember(dest => dest.BusCompany, opt => opt.Ignore());    

            CreateMap<Buses, EditBusViewModel>()
                .ForMember(dest => dest.BusCompanyId, opt => opt.MapFrom(src => src.BusCompanyId))
                .ReverseMap()
                .ForMember(dest => dest.BusId, opt => opt.Ignore())           
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());     

        }
    }
}