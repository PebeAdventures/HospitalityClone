using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Web.Models;

namespace Hospitality.Web.Mapper
{
    public class PatientDataCheckUpViewModelProfile : Profile
    {
        public PatientDataCheckUpViewModelProfile()
        {
            CreateMap<PatientDataCheckUpViewModel, ExaminationInfoDto>()
                .ForMember(eid => eid.TypeName, src => src.MapFrom(pdcvm => pdcvm.AvailableExaminations))
                .ForMember(eid => eid.PatientId, src => src.MapFrom(pdcvm => pdcvm.PatientId));
        }
    }
}
