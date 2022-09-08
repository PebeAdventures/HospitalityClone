using Hospitality.Common.DTO.Examination;

namespace Hospitality.Examination.API.Services
{
    public interface IExaminationService
    {
        Task<IEnumerable<ExaminationTypeDto>> GetAllAvailableExaminationTypesAsync();
    }
}