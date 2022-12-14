using System;
using Newtonsoft.Json;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Domain.Entities;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Domain.Entities.Enums;

namespace Hospitality.Examination.Application.Services
{
    public interface IUpdateExamination
    {
        Task updateExaminationData(string jsonData);
    }

    public class UpdateExamination : IUpdateExamination
    {
        private readonly IExaminationRepository _examinationRepository;

        public UpdateExamination(IExaminationRepository examinationRepository)
        {
            _examinationRepository = examinationRepository;
        }
        public async Task updateExaminationData(string jsonData)
        {
            ExaminationExecutionDto examinationExecutionDto = JsonConvert.DeserializeObject<ExaminationExecutionDto>(jsonData);

            int examinationID = examinationExecutionDto.Id;
            ExaminationInfo existingExamination = await _examinationRepository.GetExaminationByIdAsync(examinationID);
            ExaminationStatus statusResult = (ExaminationStatus)examinationExecutionDto.Status;
            existingExamination.Status = statusResult;
            existingExamination.Description = examinationExecutionDto.Description;
            await _examinationRepository.UpdateExaminationByNameAsync(existingExamination);
        }
    }
}
