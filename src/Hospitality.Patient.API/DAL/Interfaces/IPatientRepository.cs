namespace Hospitality.Patient.API.DAL.Interfaces
{
    public interface IPatientRepository
    {
        Task<HospitalPatient> GetById(int id);
    }
}