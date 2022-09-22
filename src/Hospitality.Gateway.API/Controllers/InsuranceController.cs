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
        private readonly IConfiguration _configuration;

        public InsuranceController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> CheckInsurance(int id)
            => Ok(await GetContentAsync($"https://localhost:7101/api/Insurance?idOfPerson={id}")); // LINK DO UZUPEŁNIENIA !!! 
        private async Task<HttpResponseMessage> GetContentAsync(string url)
            => await _httpClient.GetAsync(url);
    }
}