using AutoMapper;
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
        private IPatientService _patientService;
        private IInsuranceService _insuranceService;
        private readonly IConfiguration _configuration;

        public CheckUpController(IHttpClientFactory httpClientFactory, IMapper mapper, IPatientService patientService, IInsuranceService insuranceService, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _patientService = patientService;
            _insuranceService = insuranceService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> CheckUp(PatientDataCheckUpViewModel? patientDataCheckUpViewModel)
        {
            if (patientDataCheckUpViewModel.PatientId == 0)
            {
                patientDataCheckUpViewModel.PatientId = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"] + patientDataCheckUpViewModel.PatientPesel, HttpContext.Session.GetString("token"));
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
            patientDataCheckUpViewModel.DoctorId = Guid.Parse(User.Claims.Where(x => x.Type == "Id").First().Value);
            if (patientDataCheckUpViewModel.PatientId == 0 || patientDataCheckUpViewModel.PatientId == null)
                patientDataCheckUpViewModel.PatientId = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"] + patientDataCheckUpViewModel.PatientPesel, HttpContext.Session.GetString("token"));
            var newCheckUpDTO = _mapper.Map<NewCheckUpDTO>(patientDataCheckUpViewModel);
            await SaveNewCheckupAsync(newCheckUpDTO, _configuration["Paths:CreateCheckup"]);
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