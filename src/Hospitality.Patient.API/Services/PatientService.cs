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

        public async Task<PatientDoctorViewDTO> AddPatientAsync(PatientReceptionistViewDTO patientDTO)
        {
            HospitalPatient patientToBase = _mapper.Map<HospitalPatient>(patientDTO);
            HospitalPatient createdPatient = await _patientRepository.AddNewPatientAsync(patientToBase);
            //HospitalPatient existingPatient = await _patientRepository.GetByPesel(createdPatient.PatientPesel);
            return _mapper.Map<PatientDoctorViewDTO>(createdPatient);
        }

        public async Task<PatientDoctorViewDTO> GetPatientByPeselAsync(string pesel)
        {
            var patient = await _patientRepository.GetByPesel(pesel);
            return _mapper.Map<PatientDoctorViewDTO>(patient);
        }
    }
}
