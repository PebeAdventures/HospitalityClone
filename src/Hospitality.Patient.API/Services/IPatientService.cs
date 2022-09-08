namespace Hospitality.Patient.API.Services
{
    public interface IPatientService
    {
        Task<PatientDoctorViewDTO> GetPatientByPeselAsync(string pesel);
        Task<PatientReceptionistViewDTO> AddPatientAsync(PatientReceptionistViewDTO patientDTO);
    }
}