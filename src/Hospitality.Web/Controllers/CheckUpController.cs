﻿using AutoMapper;
using Hospitality.Common.DTO.CheckUp;
using Hospitality.Web.Models;
using Hospitality.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class CheckUpController : Controller
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IInsuranceService _insuranceService;
        private readonly IConfiguration _configuration;
        private IPatientService _patientService;

        public CheckUpController(IHttpClientFactory httpClientFactory, IMapper mapper, IInsuranceService insuranceService, IConfiguration configuration, IPatientService petientService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _insuranceService = insuranceService;
            _configuration = configuration;
            _patientService = petientService;
        }

        [HttpGet]
        public async Task<IActionResult> CheckUp(PatientDataCheckUpViewModel? patientDataCheckUpViewModel)
        {
            if (patientDataCheckUpViewModel.PatientId == 0)
                throw new Exception("Wrong order of quests");
            if (patientDataCheckUpViewModel.IsInsured == null)
                patientDataCheckUpViewModel.IsInsured = await _insuranceService.CheckHealthInsurance(
                    patientDataCheckUpViewModel.PatientId, HttpContext.Session.GetString("token"));
            return View(patientDataCheckUpViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> NewCheckUp(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {
            patientDataCheckUpViewModel.DoctorId = Guid.Parse(User.Claims.Where(x => x.Type == "Id").First().Value);

            if (patientDataCheckUpViewModel.PatientId == 0)
                throw new Exception("Wrong order of quests");
            await SaveNewCheckupAsync(_mapper.Map<NewCheckUpDTO>(patientDataCheckUpViewModel), _configuration["Paths:CreateCheckup"]);
            return RedirectToAction("Index", "Home", null);
        }

        private async Task SaveNewCheckupAsync(NewCheckUpDTO newCheckup, string url)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newCheckup), Encoding.UTF8, "application/json"));
        }
    }
}