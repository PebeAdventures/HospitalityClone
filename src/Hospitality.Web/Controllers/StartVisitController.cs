using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Hospitality.Web.Services.Interfaces;
using AutoMapper;


namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class StartVisitController : Controller
    {
        private IPatientService _patientService;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;

        private HttpClient _httpClient;




        public StartVisitController(IPatientService patientService, IConfiguration configuration,  IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _patientService = patientService;
            _configuration = configuration;


        }

        [HttpGet]
        public IActionResult StartVisit(bool? result)
        {
            if (result == false) ViewBag.Show = "show";
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> StartVisit(PatientDataCheckUpViewModel model)
        {
            var patient = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"]
               + model.PatientPesel, HttpContext.Session.GetString("token"));

            if (patient == 0) return RedirectToAction("StartVisit", "StartVisit", new { result = false });

            return RedirectToAction("CheckUp", "CheckUp", model);
        }
    }
}
