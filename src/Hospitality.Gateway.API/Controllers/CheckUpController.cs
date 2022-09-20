using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Hospitality.Common.DTO.CheckUp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net.Http.Headers;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUpController : ControllerBase
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CheckUpController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();

            _configuration = configuration;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> CreateNewCheckupAsync(NewCheckUpDTO newCheckup)
            => Ok(await GetContentAsync(newCheckup, _configuration["Paths:Checkup"])); // LINK DO UZUPEŁNIENIA !!!

        private async Task<HttpResponseMessage> GetContentAsync(NewCheckUpDTO newCheckup, string url)
        {
            var json = JsonConvert.SerializeObject(newCheckup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            return response;
        }
    }
}