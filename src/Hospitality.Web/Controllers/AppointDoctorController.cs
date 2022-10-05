using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Hospitality.Web.Models;
using AutoMapper;
using Hospitality.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Policy;
using Hospitality.Common.DTO.Patient;

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
        private IIdentityService _identityService;

        public AppointDoctorController(IHttpClientFactory httpClientFactory, IMapper mapper, IInsuranceService insuranceService, 
            IConfiguration configuration, IPatientService patientService, IIdentityService identityService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _insuranceService = insuranceService;
            _configuration = configuration;
            _patientService = patientService;
            _identityService = identityService;
        }
        [HttpGet]
        public async Task<IActionResult> AppointDoctor(bool? result)
        {
            if (result == false) ViewBag.Show = "show";
            return View(new AppointDoctorToPatientModel() { Doctors = await _identityService.GetAllDoctorsNamesAndIds(HttpContext.Session.GetString("token")) });
        }

        [HttpPost]
        public async Task<IActionResult> AppointDoctorToPatient(AppointDoctorToPatientModel model)
        {
            if (!string.IsNullOrEmpty(model.SelectedDoctorName)) model.DoctorId = await _identityService.GetIdOfSelectedDoctor(model.SelectedDoctorName, HttpContext.Session.GetString("token"));
            var patient = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"] + model.PatientPesel, HttpContext.Session.GetString("token"));
            if (patient == 0) return RedirectToAction("AppointDoctor", "AppointDoctor", new { result = false });
            var json = JsonConvert.SerializeObject(_mapper.Map<UpdateAssinedDoctorOfPatientDTO>(model));
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.PutAsync(_configuration["Paths:UpdateAssinedDoctor"], content);
            if (!response.IsSuccessStatusCode) return RedirectToAction("AppointDoctor", "AppointDoctor", new { result = false });
            return RedirectToAction("AppointDoctor", "AppointDoctor");
        }
    }
}
