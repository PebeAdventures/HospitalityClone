﻿using AutoMapper;
using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Examination;
using Hospitality.Web.Models;

namespace Hospitality.Web.Mapper
{
    public class PatientDataCheckUpViewModelProfile : Profile
    {
        public PatientDataCheckUpViewModelProfile()
        {
            CreateMap<PatientDataCheckUpViewModel, CreateExaminationDto>()
                .ForMember(eid => eid.ExaminationTypeId, src => src.MapFrom(pdcvm => pdcvm.ChosenExaminationId))
                .ForMember(eid => eid.PatientId, src => src.MapFrom(pdcvm => pdcvm.PatientId));
            CreateMap<PatientDataCheckUpViewModel, NewCheckUpDTO>()
                .ForMember(ncd => ncd.IdPatient, src => src.MapFrom(pdcvm => pdcvm.PatientId))
                .ForMember(ncd => ncd.PeselOfPatient, src => src.MapFrom(pdcvm => pdcvm.PatientPesel))
                .ForMember(ncd => ncd.IdDoctor, src => src.MapFrom(pdcvm => pdcvm.DoctorId))
                .ForMember(ncd => ncd.Description, src => src.MapFrom(pdcvm => pdcvm.Description));

        }
    }
}
