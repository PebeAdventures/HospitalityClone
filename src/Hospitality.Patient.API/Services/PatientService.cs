using AutoMapper;
using Hospitality.Patient.API.DTOs;

namespace Hospitality.Patient.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        //private IMapper _mapper;

        public PatientService(IPatientRepository patientRepository /*IMapper mapper*/)
        {
            _patientRepository = patientRepository;
            //_mapper = mapper;
        }



        // GET (single by id)

        // POST (register new patient - add)
        public async Task<PatientDoctorViewDTO> AddPatientAsync(PatientReceptionistViewDTO patientDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<PatientDoctorViewDTO> GetPatientByIdDoctorViewAsync(int id)
        {
            throw new NotImplementedException();
            //var patient = await _patientRepository.GetById(id);
            //return _mapper.Map<PatientDoctorViewDTO>(patient);
        }
    }
}
