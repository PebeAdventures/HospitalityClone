using Hospitality.Patient.API.DAL.Interfaces;

namespace Hospitality.Patient.API.DAL
{
    public class PatientRepository : BaseRepository<HospitalPatient>, IPatientRepository
    {
        private readonly PatientContext _context;
        public PatientRepository(PatientContext context) : base(context)
        { }

        public async Task<HospitalPatient> GetById(int id)
        {
            return await _context.Patients
                .Where(p => id == p.HospitalPatientId)
                .FirstOrDefaultAsync();
        }

    }
}
