using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using Hospitality.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Hospitality.Common.DTO.Patient;


namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]

    public class CheckPatientController : Controller
    {

        private HttpClient _httpClient;
        private IMapper _mapper;
        private IInsuranceService _insuranceService;
        private readonly IConfiguration _configuration;
        private IPatientService _patientService;

        public CheckPatientController(IHttpClientFactory httpClientFactory, IMapper mapper, IInsuranceService insuranceService, IConfiguration configuration, IPatientService patientService)
        {

            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _insuranceService = insuranceService;
            _configuration = configuration;
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult CheckPatient()
            => View();

        [HttpPost]
        public async Task<IActionResult> CheckPatient(AppointDoctorToPatientModel modelpesel)
        {

            var patient = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"] + modelpesel.PatientPesel, HttpContext.Session.GetString("token"));
            if (patient == 0)
            {
                return RedirectToAction("Registration", "Registration", new { pesel = modelpesel.PatientPesel });
            }

            return RedirectToAction("AppointDoctor", "AppointDoctor", new { pesel = modelpesel.PatientPesel }) ;
        }

    }
}
