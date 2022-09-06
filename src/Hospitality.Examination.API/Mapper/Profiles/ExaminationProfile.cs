﻿using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.API.Model;

namespace Hospitality.Examination.API.Mapper.Profiles
{
    public class ExaminationProfile : Profile
    {
        public ExaminationProfile()
        {
            CreateMap<ExaminationInfo, ExaminationInfoDto>();
            CreateMap<ExaminationType, ExaminationTypeDto>();
        }
    }
}