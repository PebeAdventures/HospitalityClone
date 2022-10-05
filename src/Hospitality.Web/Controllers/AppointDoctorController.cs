using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AppointDoctor(bool? result, string? pesel)
        {
            if (result == false)
            {
                ViewBag.Show = "show";
            }
            ViewBag.PeselP = pesel;
            return View(new AppointDoctorToPatientModel());
        }

        [HttpPost]
        public async Task<IActionResult> AppointDoctorToPatient(AppointDoctorToPatientModel model, string peselInput)
        {
            model.PatientPesel = peselInput;
            var patient = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"] + model.PatientPesel, HttpContext.Session.GetString("token"));
            if (patient == 0)
            {
                return RedirectToAction("AppointDoctor", "AppointDoctor", new { result = false });
            }
            return RedirectToAction("CheckPatient", "CheckPatient");
        }


    }
}
