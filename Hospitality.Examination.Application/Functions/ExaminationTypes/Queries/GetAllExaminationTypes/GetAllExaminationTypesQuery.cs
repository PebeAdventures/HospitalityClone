using Hospitality.Examination.Domain.Entities;
using MediatR;

namespace Hospitality.Examination.Application.Functions.ExaminationTypes.Queries.GetAllExaminationTypes
{
    public class GetAllExaminationTypesQuery : IRequest<List<ExaminationType>>
    {
    }
}