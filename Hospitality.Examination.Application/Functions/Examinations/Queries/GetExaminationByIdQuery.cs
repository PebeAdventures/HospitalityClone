using Hospitality.Common.DTO.Examination;
using MediatR;

namespace Hospitality.Examination.Application.Functions.Examinations.Queries
{
    public class GetExaminationByIdQuery : IRequest<ExaminationInfoDto>
    {
        public int ExaminationId { get; set; }
    }
}