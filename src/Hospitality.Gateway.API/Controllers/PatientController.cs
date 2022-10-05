﻿using Hospitality.Common.DTO.Patient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PatientController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor, Receptionist")]
        [HttpGet]
        public async Task<IActionResult> GetPatientByPeselAsync(string pesel)
            => Ok(await _httpClient.GetStringAsync(_configuration["Paths:GetPatientByPesel"] + pesel));

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
        [HttpPost]
        public async Task<IActionResult> RegisterNewPatientAsync(PatientReceptionistViewDTO newPatient)
            => await GetContentAsync(newPatient, _configuration["Paths:RegisterPatient"]);

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
        [HttpPut("UpdateAssinedDoctor")]
        public async Task<IActionResult> UpdateAssignedDoctor(UpdateAssinedDoctorOfPatientDTO patientDTO)
        {
            var json = JsonConvert.SerializeObject(patientDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(_configuration["Paths:UpdateAssinedDoctorOfPatient"], content);
            if (!response.IsSuccessStatusCode || response is null) return NotFound();
            return NoContent();
        }
    
        private async Task<IActionResult> GetContentAsync(PatientReceptionistViewDTO newPatient, string url)
        {
            var json = JsonConvert.SerializeObject(newPatient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return NotFound(); ;
            return StatusCode(201);
        }
    }
}