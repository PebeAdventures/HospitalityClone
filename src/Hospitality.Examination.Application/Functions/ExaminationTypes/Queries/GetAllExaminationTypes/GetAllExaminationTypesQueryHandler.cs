using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Domain.Entities;
using MediatR;

namespace Hospitality.Examination.Application.Functions.ExaminationTypes.Queries.GetAllExaminationTypes
{
    public class GetAllExaminationTypesQueryHandler : IRequestHandler<GetAllExaminationTypesQuery, List<ExaminationTypeDto>>
    {
        private readonly IExaminationTypesRepository _examinationTypesRepository;
        private readonly IMapper _mapper;

        public GetAllExaminationTypesQueryHandler(IExaminationTypesRepository examinationTypesRepository, IMapper mapper)
        {
            _examinationTypesRepository = examinationTypesRepository;
            _mapper = mapper;
        }

        public async Task<List<ExaminationTypeDto>> Handle(GetAllExaminationTypesQuery request, CancellationToken cancellationToken)
        {
            var orders = await _examinationTypesRepository.GetAllExaminationTypesAsync();
            return _mapper.Map<List<ExaminationTypeDto>>(orders);
        }
    }
}