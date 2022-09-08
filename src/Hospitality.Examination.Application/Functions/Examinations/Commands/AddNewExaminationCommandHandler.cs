using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Domain.Entities;
using MediatR;

namespace Hospitality.Examination.Application.Functions.Examinations.Commands
{
    public class AddNewExaminationCommandHandler : IRequestHandler<AddNewExaminationCommand, ExaminationInfoDto>
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IMapper _mapper;

        public AddNewExaminationCommandHandler(IExaminationRepository examinationRepository, IMapper mapper)
        {
            _examinationRepository = examinationRepository;
            _mapper = mapper;
        }

        public async Task<ExaminationInfoDto> Handle(AddNewExaminationCommand request, CancellationToken cancellationToken)
        {
            var examination = _mapper.Map<ExaminationInfo>(request);
            var createdExamination = await _examinationRepository.AddNewExaminationAsync(examination);
            var existingExamination = await _examinationRepository.GetExaminationByIdAsync(createdExamination.Id);
            return _mapper.Map<ExaminationInfoDto>(existingExamination);
        }
    }
}