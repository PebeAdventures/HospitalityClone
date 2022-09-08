using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospitality.Examination.API.Services
{
    public class ExaminationService : IExaminationService
    {
        private readonly ExaminationContext _context;
        private readonly IMapper _mapper;

        public ExaminationService(ExaminationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExaminationTypeDto>> GetAllAvailableExaminationTypesAsync()
        {
            var examinationTypes = await _context.ExaminationTypes.ToListAsync();
            return _mapper.Map<IEnumerable<ExaminationTypeDto>>(examinationTypes);
        }
    }
}