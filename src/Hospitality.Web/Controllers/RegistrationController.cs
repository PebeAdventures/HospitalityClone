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

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
    public class RegistrationController : Controller
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        public RegistrationController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Registration(PatientResultViewModel? Model)
        {
            if (Model.Result == "valid")
                return View();
            else 
                ViewBag.Invalid = Model.Result;
                return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPostAsync(PatientResultViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Result = "invalid";
                return RedirectToAction("Registration", "Registration", model);
            }
            model.Result = "valid";
            await RegisterNewPatient(model, "https://localhost:7236/api/Patient");
            return RedirectToAction("Registration", "Registration", model);
        }

        private async Task RegisterNewPatient(PatientResultViewModel model, string url)
        {
            PatientReceptionistViewDTO mapedPatient = _mapper.Map<PatientReceptionistViewDTO>(model);
            model.IsInsured = await CheckHealthInsurance(mapedPatient.Id);
            var json = JsonConvert.SerializeObject(mapedPatient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, content);
        }

        private async Task<bool> CheckHealthInsurance(int idOfPerson)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.GetAsync($"https://localhost:7236/api/Insurance?idOfPerson={idOfPerson}");
            return JsonConvert.DeserializeObject<InsuredDTO>(await response.Content.ReadAsStringAsync()).IsInsured;
        }
    }
}
