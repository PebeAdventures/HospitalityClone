using Hospitality.Common.DTO.CheckUp;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUpController : ControllerBase
    {

        private HttpClient _httpClient;
        public CheckUpController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

        [HttpPost]
        [Route("/newcheckups")]
        public async Task<IActionResult> CreateNewCheckupAsync(NewCheckUpDTO newCheckup)
        {
            var json = JsonConvert.SerializeObject(newCheckup);
            return await GetContentAsync(json, "http://hospitality.checkup.api/newcheckup"); // LINK DO UZUPEŁNIENIA !!! 
        }

        private async Task<ContentResult> GetContentAsync(string json, string url)
        {
            //var json = JsonConvert.SerializeObject(newCheckup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            /* if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
             return StatusCode(201);*/
            return Content(result);
        }
    }
}
