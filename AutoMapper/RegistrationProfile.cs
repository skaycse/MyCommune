using AutoMapper;
using MyCommune.DataModels.Account;
using MyCommune.DataModels.Users;
using MyCommune.Models.ViewModel.Account;

namespace MyCommune.AutoMapper
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<Registration, User>()
                .ForMember(d => d.Email, a => a.MapFrom(m => m.Email))
                .ForMember(d => d.Mobile, a => a.MapFrom(m => m.Mobile))
                .ForMember(d => d.Password, a => a.MapFrom(m => m.Password));

            CreateMap<RegistrationModel, Registration>();

        }
    }
}
