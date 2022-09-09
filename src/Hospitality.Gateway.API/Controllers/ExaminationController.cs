﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private HttpClient _httpClient;
        public ExaminationController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

        [HttpGet]
        [Route("/types")]
        public async Task<IActionResult> GetListOfTypesExaminationAsync()
            => Ok(await _httpClient.GetStringAsync("")); // LINK DO UZUPEŁNIENIA !!! 

        [HttpGet]
        [Route("/current")]
        public async Task<IActionResult> GetCurrentPatientExaminationsResultsAsync()
            => Ok(await _httpClient.GetStringAsync("")); // LINK DO UZUPEŁNIENIA !!! 

        [HttpPost]
        [Route("/current")]
        public async Task<IActionResult> AddNewExaminationAsync(object newExamination)
            => await GetContent(newExamination, ""); // LINK DO UZUPEŁNIENIA !!! 
        private async Task<IActionResult> GetContent(object newExamination, string url)
        {
            var json = JsonConvert.SerializeObject(newExamination);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }
    }
}
