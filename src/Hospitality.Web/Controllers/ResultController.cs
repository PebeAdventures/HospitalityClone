using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Web.Controllers
{
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

        public IActionResult Result()
        {
            return View(results);
        }
    }
}
