using Hospitality.Patient.API.DTOs;
namespace Hospitality.Patient.API.Services
{
    public interface IPatientService
    {
        Task<PatientDoctorViewDTO> GetPatientByIdDoctorViewAsync(int id);
        Task<PatientDoctorViewDTO> AddPatientAsync(PatientReceptionistViewDTO patientDTO);
    }
}
