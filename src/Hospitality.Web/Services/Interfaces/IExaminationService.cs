using Hospitality.Common.DTO.Examination;

namespace Hospitality.Web.Services.Interfaces
{
    public interface IExaminationService
    {
        Task<List<ExaminationTypeDto>> GetAvailableExaminations(string token);
    }
}