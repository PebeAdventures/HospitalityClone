using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Patient;
using Hospitality.Common.Models.Exceptions;

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
            if (patientDTO == null)
                throw new ResourceNotFoundException($"{nameof(patientDTO)} not found");

            HospitalPatient hospitalPatient = new()
            {
                PatientName = patientDTO.PatientName,
                PatientSurname = patientDTO.PatientSurname,
                PatientPesel = patientDTO.PatientPesel,
                BirthDate = patientDTO.BirthDate,
                Address = patientDTO.Address,
                Email = patientDTO.Email,
                PhoneNumber = patientDTO.PhoneNumber,
                IsInsured = patientDTO.IsInsured
            };


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
            if (pesel is null || pesel.Length == 0)
                throw new BadRequestException("Pesel can't be null");

            var patient = await _patientRepository.GetByPesel(pesel);
            if (patient is null)
                throw new BadRequestException("Patient can't be null");
            return _mapper.Map<PatientDoctorViewDTO>(patient);
        }

        public async Task<PatientNotificationDTO> GetPatientByIDAsync(int patientID)
        {
            var patient = await _patientRepository.GetPatientByID(patientID);
            if (patient is null)
                throw new BadRequestException("Patient can't be null");
            return _mapper.Map<PatientNotificationDTO>(patient);
        }
    }
}
