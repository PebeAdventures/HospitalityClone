using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private HttpClient _httpClient;
        public InsuranceController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

        [HttpGet]
        public async Task<IActionResult> CreateNewCheckupAsync(int id)
            => Ok(await GetContentAsync($"https://localhost:7101/api/Insurance?idOfPerson={id}")); // LINK DO UZUPEŁNIENIA !!! 
        private async Task<HttpResponseMessage> GetContentAsync(string url)
            => await _httpClient.GetAsync(url);
    }
}
