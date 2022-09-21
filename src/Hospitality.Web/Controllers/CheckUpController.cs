using Hospitality.Common.DTO.CheckUp;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Hospitality.Common.DTO.Patient;
using Hospitality.Common.DTO.Examination;
using AutoMapper;

namespace Hospitality.Web.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class CheckUpController : Controller
    {
        private HttpClient _httpClient;
        private IMapper _mapper;

        public CheckUpController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {   
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> CheckUp(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {
            var availableExaminatios = await GetAvailableExaminations();
            patientDataCheckUpViewModel.AvailableExaminations = availableExaminatios.Select(x => x.Name).ToList();
            if (patientDataCheckUpViewModel.PatientId != 0 || patientDataCheckUpViewModel.PatientId != null)
            {
                return View(patientDataCheckUpViewModel);
            }
            else
            {
                var idOfPatient = await GetIdOfPatient($"https://localhost:7236/api/Patient?pesel={patientDataCheckUpViewModel.PatientPesel}");
                if (idOfPatient != 0)
                {
                    patientDataCheckUpViewModel.PatientId = idOfPatient;
                    return View(patientDataCheckUpViewModel);
                }
                else return RedirectToAction("StartVisit", "StartVisit", patientDataCheckUpViewModel);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> NewCheckUp(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {

            patientDataCheckUpViewModel.DoctorId = 1;
            var newCheckUpDTO = _mapper.Map<NewCheckUpDTO>(patientDataCheckUpViewModel);
            await SaveNewCheckupAsync(newCheckUpDTO, "https://localhost:7236/api/CheckUp");
            return RedirectToAction("Index", "Home", null);
        }

        [HttpPost]
        public async Task<IActionResult> OrderAnExamination(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {
            if (!string.IsNullOrEmpty(patientDataCheckUpViewModel.ChosenExamination))
                await AssignIdOfChosenExamination(patientDataCheckUpViewModel);
                await SendOrder(patientDataCheckUpViewModel, "URL");
            return RedirectToAction("CheckUp", "CheckUp", patientDataCheckUpViewModel);
        }

        private async Task AssignIdOfChosenExamination(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
            => patientDataCheckUpViewModel.ChosenExaminationId = (await GetAvailableExaminations()).Where(ae => ae.Name == patientDataCheckUpViewModel.ChosenExamination).FirstOrDefault().Id;
        
        private async Task<List<ExaminationTypeDto>> GetAvailableExaminations()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.GetAsync("https://localhost:7236/api/Examination/TypesOfExaminations");
            if (!response.IsSuccessStatusCode || response is null)
                throw new Exception("Null response exception");
            var availableExaminations = JsonConvert.DeserializeObject<List<ExaminationTypeDto>>(await response.Content.ReadAsStringAsync());
            if (availableExaminations is null)
                throw new Exception("Null response exception");
            return availableExaminations;
        }
        private async Task SendOrder(PatientDataCheckUpViewModel patientDataCheckUpViewModel, string url)
        {
            var examinationDto = _mapper.Map<CreateExaminationDto>(patientDataCheckUpViewModel);
            var json = JsonConvert.SerializeObject(examinationDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, content);
        }

        private async Task<int> GetIdOfPatient(string url)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode || response is null) return 0;
            var patientDoctorViewDTO = JsonConvert.DeserializeObject<PatientDoctorViewDTO>(await response.Content.ReadAsStringAsync());
            if (patientDoctorViewDTO is null) return 0;
            return patientDoctorViewDTO.HospitalPatientId;
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