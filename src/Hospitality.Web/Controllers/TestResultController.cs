using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Web.Controllers
{
    public class TestResultController : Controller
    {
        private List<TestResultClass> results;

        public TestResultController()
        {
            results = new List<TestResultClass>() {
                new TestResultClass(){ name = "Badanie krwi", result = "niski poziom hemoglobiny", price = 50},
                new TestResultClass(){ name = "USG serca", result = "bez patalogii", price = 300},
                new TestResultClass(){ name = "Test na alergeny", result = "pozytywny na brzoze", price = 250}
            };
        }

        public IActionResult TestResult()
        {
            return View(results);
        }
    }
}
