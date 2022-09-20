using Hospitality.Patient.API.DAL.Interfaces;
using Hospitality.Patient.API.Data.Context;

namespace Hospitality.Patient.API.DAL
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext _context;
        public PatientRepository(PatientContext context)
        {
            _context = context;
        }

        public async Task<HospitalPatient> GetByPesel(string pesel)
        {
            return await _context.Patients
                .Where(p => pesel == p.PatientPesel)
                .FirstOrDefaultAsync();
        }
        public async Task<HospitalPatient> GetPatientByID(int patientID)
        {
            return await _context.Patients
                .Where(p => p.HospitalPatientId == patientID)
                .FirstOrDefaultAsync();
        }

        public async Task<HospitalPatient> AddNewPatientAsync(HospitalPatient patient)
        {
            var result = await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

    }
}
