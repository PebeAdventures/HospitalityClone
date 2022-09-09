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
            //HospitalPatient patientToBase = _mapper.Map<HospitalPatient>(patientDTO);
            //HospitalPatient createdPatient = await _patientRepository.AddNewPatientAsync(patientToBase);
            ////HospitalPatient existingPatient = await _patientRepository.GetByPesel(createdPatient.PatientPesel);
            //return _mapper.Map<PatientReceptionistViewDTO>(createdPatient);
        }

        //public async Task AddNewCheckUp(NewCheckUpDTO newCheckUpDTO)
        //{

        //    await CheckUpContext.CheckUps.AddAsync(new CheckUpModel
        //    {
        //        Description = newCheckUpDTO.Description,
        //        IdDoctor = newCheckUpDTO.IdDoctor,
        //        IdPatient = newCheckUpDTO.IdPatient,
        //        Time = DateTime.Now
        //    });
        //    CheckUpContext.SaveChanges();
        //}

        public async Task<PatientDoctorViewDTO> GetPatientByPeselAsync(string pesel)
        {
            var patient = await _patientRepository.GetByPesel(pesel);
            return _mapper.Map<PatientDoctorViewDTO>(patient);
        }
    }
}
