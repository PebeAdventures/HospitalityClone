using Hospitality.Common.DTO.Registration;

namespace Hospitality.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<List<DoctorDTO>> GetAllDoctorsNamesAndIds(string token);
    }
}