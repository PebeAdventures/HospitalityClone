using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private HttpClient _httpClient;

        public PatientController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();
        //Checkup:

        //POST:  Create new Checkup

        //Examination:

        //POST(dodawanie exmination do pacjenta)
        //GET(examination Type List)
        //GET(Get Current Patient Examination's results)

        //Identity:

        //POST: log in

        //Patient:

        //POST(register new patient - add)

        [HttpPost]
        public async Task<IActionResult> RegisterNewPatient(object newPatient)
            => await GetContent(newPatient, ""); // LINK DO UZUPEŁNIENIA !!! 
        private async Task<IActionResult> GetContent(object newPatient, string url)
        {
            var json = JsonConvert.SerializeObject(newPatient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }
    }
}
