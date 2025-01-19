using AutoMapper;
using RidePoint.Models.Entities;
using RidePoint.ViewModel.Authenticate;

namespace RidePoint.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, RegisterViewModel>().ReverseMap();
            CreateMap<User, EditUserViewModel>().ReverseMap();
        }
    }
}