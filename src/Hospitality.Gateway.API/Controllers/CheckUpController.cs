﻿using Hospitality.Common.DTO.CheckUp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IConfiguration _configuration;

        public CheckUpController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> CreateNewCheckupAsync(NewCheckUpDTO newCheckup)
        {
            return Ok(await GetContentAsync(newCheckup, _configuration["Paths:CreateCheckup"]));
        }

        private async Task<HttpResponseMessage> GetContentAsync(NewCheckUpDTO newCheckup, string url)
        => await _httpClient.PostAsync(url, new StringContent(
            JsonConvert.SerializeObject(newCheckup), Encoding.UTF8, "application/json"));
    }
}