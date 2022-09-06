using Hospitality.Common.DTO.CheckUp;

namespace Hospitality.CheckUp.API.Service.Interface
{
    public interface ICheckUpService
    {

        void AddNewCheckUp(NewCheckUpDTO newCheckUpDTO);
    }
}
