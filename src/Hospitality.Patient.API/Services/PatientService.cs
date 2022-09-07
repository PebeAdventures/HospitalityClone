using AutoMapper;
using Hospitality.Patient.API.DTOs;

namespace Hospitality.Patient.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<HospitalPatient> _hospitalRepository;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }


        // POST (register new patient - add)
        public async Task<PatientDoctorViewDTO> AddPatientAsync(PatientReceptionistViewDTO patientDTO)
        {

            var newPatient = _mapper.Map<HospitalPatient>(patientDTO);

            var insertMaterial = await _hospitalRepository.AddAsync(newPatient);
            return _mapper.Map<PatientDoctorViewDTO>(insertMaterial);
        }

        public async Task<PatientDoctorViewDTO> GetPatientByPeselAsync(string pesel)
        {
            var patient = await _patientRepository.GetByPesel(pesel);
            return _mapper.Map<PatientDoctorViewDTO>(patient);
        }
    }
}
