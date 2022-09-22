namespace Hospitality.Web.Services.Interfaces
{
    public interface IPatientService
    {
        Task<int> GetIdOfPatient(string url, string token);
    }
}