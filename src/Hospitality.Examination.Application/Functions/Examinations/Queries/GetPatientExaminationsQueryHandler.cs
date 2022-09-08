using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Application.Contracts.Persistence;
using MediatR;

namespace Hospitality.Examination.Application.Functions.Examinations.Queries
{
    public class GetPatientExaminationsQueryHandler : IRequestHandler<GetPatientExaminationsQuery, List<ExaminationInfoDto>>
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IMapper _mapper;

        public GetPatientExaminationsQueryHandler(IExaminationRepository examinationRepository, IMapper mapper)
        {
            _examinationRepository = examinationRepository;
            _mapper = mapper;
        }

        public async Task<List<ExaminationInfoDto>> Handle(GetPatientExaminationsQuery request, CancellationToken cancellationToken)
        {
            var patientId = request.PatientId;
            var result = await _examinationRepository.GetPatientExaminationsAsync(patientId);
            return _mapper.Map<List<ExaminationInfoDto>>(result);
        }
    }
}