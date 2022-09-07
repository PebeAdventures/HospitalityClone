using Hospitality.Patient.API.DTOs;
namespace Hospitality.Patient.API.Services
{
    public interface IPatientService
    {
        Task<PatientDoctorViewDTO> GetPatientByPeselAsync(string pesel);
        Task<PatientDoctorViewDTO> AddPatientAsync(PatientReceptionistViewDTO patientDTO);
    }
}