using Hospitality.Common.DTO.CheckUp;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class ResultController : Controller
    {
        private List<ResultClass> results;

        public ResultController()
        {
            results = new List<ResultClass>() {
                new ResultClass(){ name = "Badanie krwi", result = "niski poziom hemoglobiny", price = 50},
                new ResultClass(){ name = "USG serca", result = "bez patalogii", price = 300},
                new ResultClass(){ name = "Test na alergeny", result = "pozytywny na brzoze", price = 250}
            };
        }

        public IActionResult Result(string patientPesel, string checkUpDescription)
        {

            //NewCheckUpDTO checkUpDto = Request.Form["patient"].First();
            return View(results);
        }
    }
}
