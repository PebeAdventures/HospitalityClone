﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Hospitality.Common.DTO.Patient;
using Hospitality.Common.DTO.NewFolder;
using System;
using Hospitality.Web.Models;
using AutoMapper;
using Hospitality.Web.Services.Interfaces;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]

    public class AppointDoctorController : Controller
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IInsuranceService _insuranceService;
        private readonly IConfiguration _configuration;
        private IPatientService _patientService;

        public AppointDoctorController(IHttpClientFactory httpClientFactory, IMapper mapper, IInsuranceService insuranceService, IConfiguration configuration, IPatientService patientService)
        {

            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _insuranceService = insuranceService;
            _configuration = configuration;
            _patientService = patientService;
        }
        public IActionResult AppointDoctor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AppointDoctorToPatient(AppointDoctorToPatientModel model)
        {
            var patientModel = model;
            var patient = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"] + model.PatientPesel, HttpContext.Session.GetString("token"));
            return RedirectToAction("AppointDoctor", "AppointDoctor");
        }


    }
}
