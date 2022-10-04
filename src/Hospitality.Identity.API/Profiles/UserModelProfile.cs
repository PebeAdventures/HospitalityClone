using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Common.DTO.Registration;
using Microsoft.AspNetCore.Identity;

namespace Hospitality.Identity.API.Profiles
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<IdentityUser, DoctorDTO>()
                .ForMember(dd => dd.Name, e => e.MapFrom(id => id.UserName))
                .ForMember(dd => dd.Id, e => e.MapFrom(id => id.Id));
        }
    }
}
