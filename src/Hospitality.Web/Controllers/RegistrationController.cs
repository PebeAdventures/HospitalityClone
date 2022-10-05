﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Hospitality.Common.DTO.Patient;
using Hospitality.Web.Models;
using AutoMapper;
using Hospitality.Web.Services.Interfaces;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
    public class RegistrationController : Controller
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IInsuranceService _insuranceService;
        private readonly IConfiguration _configuration;
        private IIdentityService _identityService;

        public RegistrationController(IHttpClientFactory httpClientFactory, IMapper mapper, IInsuranceService insuranceService, 
            IConfiguration configuration, IIdentityService identityService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _insuranceService = insuranceService;
            _configuration = configuration;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<IActionResult> Registration(PatientResultViewModel? Model)
        {
            if (Model.Result == "valid")
            {
                return View(new PatientResultViewModel() { Doctors = await _identityService.GetAllDoctorsNamesAndIds(HttpContext.Session.GetString("token")) });
            }
            else
            {
                ViewBag.Invalid = Model.Result;
                Model.Doctors = await _identityService.GetAllDoctorsNamesAndIds(HttpContext.Session.GetString("token"));
                return View(Model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPostAsync(PatientResultViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Result = "invalid";
                return RedirectToAction("Registration", "Registration", model);
            }
            model.IdOfSelectedDoctor = await _identityService.GetIdOfSelectedDoctor(model.NameOfSelectedDoctor, HttpContext.Session.GetString("token"));
            model.Result = "valid";
            await RegisterNewPatient(model, _configuration["Paths:CreatePatient"]);
            return RedirectToAction("Registration", "Registration");
        }

        private async Task RegisterNewPatient(PatientResultViewModel model, string url)
        {
            PatientReceptionistViewDTO mapedPatient = _mapper.Map<PatientReceptionistViewDTO>(model);
            mapedPatient.IsInsured = await _insuranceService.CheckHealthInsurance(mapedPatient.Id, HttpContext.Session.GetString("token"));
            var json = JsonConvert.SerializeObject(mapedPatient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, content);
        }
    }
}
