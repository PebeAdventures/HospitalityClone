using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Patient;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Hospitality.Common.DTO.Patient;
using Hospitality.Common.DTO.Examination;
using AutoMapper;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Hospitality.Web.Services.Interfaces;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class CheckUpController : Controller
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IPatientService _patientService;
        private IInsuranceService _insuranceService;

        public CheckUpController(IHttpClientFactory httpClientFactory, IMapper mapper, IPatientService patientService, IInsuranceService insuranceService)
        {   
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _patientService = patientService;
            _insuranceService = insuranceService;
        }
        [HttpGet]
        public async Task<IActionResult> CheckUp(PatientDataCheckUpViewModel? patientDataCheckUpViewModel)
        {
            if (patientDataCheckUpViewModel.PatientId == 0)
            {
                patientDataCheckUpViewModel.PatientId = await _patientService.GetIdOfPatient($"https://localhost:7236/api/Patient?pesel={patientDataCheckUpViewModel.PatientPesel}", HttpContext.Session.GetString("token"));
                if (patientDataCheckUpViewModel.PatientId == 0)
                    return RedirectToAction("StartVisit", "StartVisit", patientDataCheckUpViewModel);
            }
            if (patientDataCheckUpViewModel.IsInsured == null)
                patientDataCheckUpViewModel.IsInsured = await _insuranceService.CheckHealthInsurance(patientDataCheckUpViewModel.PatientId, HttpContext.Session.GetString("token"));
            return View(patientDataCheckUpViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> NewCheckUp(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {
            if (patientDataCheckUpViewModel.PatientId == 0 || patientDataCheckUpViewModel.PatientId == null)
                patientDataCheckUpViewModel.PatientId = await _patientService.GetIdOfPatient($"https://localhost:7236/api/Patient?pesel={patientDataCheckUpViewModel.PatientPesel}", HttpContext.Session.GetString("token"));
            patientDataCheckUpViewModel.DoctorId = 1;
            var newCheckUpDTO = _mapper.Map<NewCheckUpDTO>(patientDataCheckUpViewModel);
            await SaveNewCheckupAsync(newCheckUpDTO, "https://localhost:7236/api/CheckUp");
            return RedirectToAction("Index", "Home", null);
        }

        private async Task SaveNewCheckupAsync(NewCheckUpDTO newCheckup, string url)
        {
            var json = JsonConvert.SerializeObject(newCheckup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, content);
        }
    }
}