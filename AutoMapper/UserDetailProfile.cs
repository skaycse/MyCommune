using AutoMapper;
using MyCommune.DataModels.Users;
using MyCommune.Models.ViewModel.User;

namespace MyCommune.AutoMapper
{
    public class UserDetailProfile : Profile
    {
        public UserDetailProfile()
        {
            CreateMap<User, UserDetailViewModel>()
                .ForMember(d => d.Id, a => a.MapFrom(m => m.Id))
                .ForMember(d => d.FirstName, a => a.MapFrom(m => m.UserDetails.FirstName))
                .ForMember(d => d.LastName, a => a.MapFrom(m => m.UserDetails.LastName))
                .ForMember(d => d.Email, a => a.MapFrom(m => m.Email))
                .ForMember(d => d.Mobile, a => a.MapFrom(m => m.Mobile))
                .ForMember(d => d.Address, a => a.MapFrom(m => m.UserDetails.Address))
                .ForMember(d => d.UserDetailId, a => a.MapFrom(m => m.UserDetails.Id))
                .ReverseMap();
        }
    }
}
