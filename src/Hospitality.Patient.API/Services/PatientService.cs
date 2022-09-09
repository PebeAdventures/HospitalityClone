using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Patient;
namespace Hospitality.Patient.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task AddPatientAsync(PatientReceptionistViewDTO patientDTO)
        {
            await _patientRepository.AddNewPatientAsync(new HospitalPatient
            {
                PatientName = patientDTO.PatientName,
                PatientSurname = patientDTO.PatientSurname,
                PatientPesel = patientDTO.PatientPesel,
                BirthDate = patientDTO.BirthDate,
                Address = patientDTO.Address,
                Email = patientDTO.Email,
                PhoneNumber = patientDTO.PhoneNumber,
                IsInsured = patientDTO.IsInsured
            });
        }

        public async Task<PatientDoctorViewDTO> GetPatientByPeselAsync(string pesel)
        {
            var patient = await _patientRepository.GetByPesel(pesel);
            return _mapper.Map<PatientDoctorViewDTO>(patient);
        }
    }
}
