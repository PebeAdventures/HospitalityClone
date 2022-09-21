using Hospitality.CheckUp.API.DataBase.Context;
using Hospitality.CheckUp.API.DataBase.Entity;
using Hospitality.CheckUp.API.Service.Interface;
using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.Models.Exceptions;

namespace Hospitality.CheckUp.API.Service
{
    public class CheckUpService : ICheckUpService
    {
        private CheckUpContext CheckUpContext { get; set; }

        public CheckUpService(CheckUpContext checkUpContext)
        {
            CheckUpContext = checkUpContext;
        }

        public async Task AddNewCheckUp(NewCheckUpDTO newCheckUpDTO)

        {
            if (newCheckUpDTO == null)
                throw new ResourceNotFoundException($"There is no check up to create");
            
            await CheckUpContext.CheckUps.AddAsync(new CheckUpModel
            {
                Description = newCheckUpDTO.Description,
                IdDoctor = newCheckUpDTO.IdDoctor,
                IdPatient = newCheckUpDTO.IdPatient,
                Time = DateTime.Now
            });
            CheckUpContext.SaveChanges();
        }
    }
}
