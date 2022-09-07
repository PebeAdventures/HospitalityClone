using Hospitality.Patient.API.DAL.Interfaces;
using Hospitality.Patient.API.Data.Context;

namespace Hospitality.Patient.API.DAL
{
    public class PatientRepository : BaseRepository<HospitalPatient>, IPatientRepository
    {
        private readonly PatientContext _context;
        public PatientRepository(PatientContext context) : base(context)
        {
            _context = context;
        }

        public async Task<HospitalPatient> GetByPesel(string pesel)
        {
            return await _context.Patients
                .Where(p => pesel == p.PatientPesel)
                .FirstOrDefaultAsync();
        }

    }
}
