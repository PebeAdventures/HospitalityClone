using AutoMapper;
using Hospitality.Patient.API.Data.Context;
using Hospitality.Patient.API.DTOs;

namespace Hospitality.Patient.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<HospitalPatient> _hospitalRepository;
        private readonly PatientContext _context;

        public PatientService(IPatientRepository patientRepository, IMapper mapper, PatientContext context)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _context = context;
        }


        // POST (register new patient - add)
        //public async Task<PatientDoctorViewDTO> AddPatientAsync(PatientReceptionistViewDTO patientDTO)
        //{

        //    var newPatient = _mapper.Map<HospitalPatient>(patientDTO);

        //    var insertMaterial = await _context.Patients.AddAsync(newPatient);
        //    return _mapper.Map<PatientDoctorViewDTO>(insertMaterial);
        //} 
        public async Task AddPatientAsync(PatientReceptionistViewDTO patientDTO)
        {

            PatientDoctorViewDTO newPatient = _mapper.Map<PatientDoctorViewDTO>(patientDTO);
            HospitalPatient patientToBase = _mapper.Map<HospitalPatient>(newPatient);
            await _context.Patients.AddAsync(patientToBase);
            _context.SaveChangesAsync();
        }

        public async Task<PatientDoctorViewDTO> GetPatientByPeselAsync(string pesel)
        {
            var patient = await _patientRepository.GetByPesel(pesel);
            return _mapper.Map<PatientDoctorViewDTO>(patient);
        }
    }
}
