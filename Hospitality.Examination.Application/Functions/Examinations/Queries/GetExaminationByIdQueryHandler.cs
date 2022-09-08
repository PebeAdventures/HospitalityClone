using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Application.Contracts.Persistence;
using MediatR;

namespace Hospitality.Examination.Application.Functions.Examinations.Queries
{
    public class GetExaminationByIdQueryHandler : IRequestHandler<GetExaminationByIdQuery, ExaminationInfoDto>
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IMapper _mapper;

        public GetExaminationByIdQueryHandler(IExaminationRepository examinationRepository, IMapper mapper)
        {
            _examinationRepository = examinationRepository;
            _mapper = mapper;
        }

        public async Task<ExaminationInfoDto> Handle(GetExaminationByIdQuery request, CancellationToken cancellationToken)
        {
            var examination = await _examinationRepository.GetExaminationByIdAsync(request.ExaminationId);
            return _mapper.Map<ExaminationInfoDto>(examination);
        }
    }
}