using AutoMapper;
using Hospitality.Common.DTO.Patient;
using Hospitality.Web.Models;

namespace Hospitality.Web.Mapper
{
    public class PatientResultViewModelProfile : Profile
    {
        public PatientResultViewModelProfile()
        {
            CreateMap<PatientResultViewModel, PatientReceptionistViewDTO>().ReverseMap();
        }
    }
}
