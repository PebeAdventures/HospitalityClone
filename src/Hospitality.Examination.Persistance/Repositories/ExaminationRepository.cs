using Hospitality.Examination.API.Model;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospitality.Examination.Persistance.Repositories
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly ExaminationContext _context;

        public ExaminationRepository(ExaminationContext context)
        {
            _context = context;
        }

        public async Task<ExaminationInfo> AddNewExaminationAsync(ExaminationInfo examination)
        {
            var result = await _context.Examinations.AddAsync(examination);
            await _context.SaveChangesAsync();
            return examination;
        }

        public async Task<IEnumerable<ExaminationInfo>> GetPatientExaminationsAsync(int patientId)
        {
            var examinations = await _context.Examinations.Where(e => e.PatientId == patientId).Include(e => e.Type).ToListAsync();
            return examinations;
        }
        public async Task<ExaminationInfo> GetExaminationByIdAsync(int id) => await _context.Examinations.Include(e => e.Type).SingleOrDefaultAsync(e => e.Id == id);

        public async Task UpdateExaminationByNameAsync(ExaminationInfo examination)
        {
            _context.Examinations.Update(examination);
            await _context.SaveChangesAsync();
        }
    }
}