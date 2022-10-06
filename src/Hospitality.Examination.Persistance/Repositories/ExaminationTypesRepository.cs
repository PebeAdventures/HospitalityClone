using Hospitality.Examination.API.Model;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospitality.Examination.Persistance.Repositories
{
    public class ExaminationTypesRepository : IExaminationTypesRepository
    {
        private readonly ExaminationContext _context;

        public ExaminationTypesRepository(ExaminationContext context)
            =>_context = context;

        public async Task<IEnumerable<ExaminationType>> GetAllExaminationTypesAsync() 
            => await _context.ExaminationTypes.ToListAsync();
    }
}