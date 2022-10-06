using AutoMapper;
using Hospitality.Common.DTO.Patient;
using Hospitality.Web.Models;

namespace Hospitality.Web.Mapper
{
    public class UpdatePatientDTOProfile : Profile
    {
        public UpdatePatientDTOProfile()
            => CreateMap<AppointDoctorToPatientModel, UpdateAssinedDoctorOfPatientDTO>();
    }
}
