using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Application.Functions.Examinations.Commands;
using Hospitality.Examination.Domain.Entities;

namespace Hospitality.Examination.Application.Mapper.Profiles
{
    public class ExaminationProfile : Profile
    {
        public ExaminationProfile()
        {
            CreateMap<ExaminationInfo, ExaminationInfoDto>()
                .ForMember(x => x.Status, e => e.MapFrom(m => m.Status.ToString()))
                .ForMember(x => x.TypeName, e => e.MapFrom(m => m.Type.Name));
            CreateMap<ExaminationType, ExaminationTypeDto>();
            CreateMap<AddNewExaminationCommand, ExaminationInfo>()
                .ForMember(x => x.Status, e => e.MapFrom(m => m.Status));
        }
    }
}