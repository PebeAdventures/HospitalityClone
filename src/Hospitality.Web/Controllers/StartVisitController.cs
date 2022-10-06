using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Hospitality.Web.Services.Interfaces;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class StartVisitController : Controller
    {
        private IPatientService _patientService;
        private IConfiguration _configuration;
        public StartVisitController(IPatientService patientService, IConfiguration configuration)
        {
            _patientService = patientService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult StartVisit()
            => View();

        [HttpPost]
        public async Task<IActionResult> StartVisit(PatientDataCheckUpViewModel model)
        {
            model.PatientId = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"]
                + model.PatientPesel, HttpContext.Session.GetString("token"));

            if (model.PatientId == 0)
                return RedirectToAction("StartVisit", "StartVisit", model);
            
            model.DoctorId = Guid.Parse(User.Claims.Where(x => x.Type == "Id").First().Value);
            if (!(await IfPatientIsAssignToLoggedDoctor(model)))
                return RedirectToAction("StartVisit", "StartVisit", model);
            model.PatientPesel = "";
            return RedirectToAction("CheckUp", "CheckUp", model);
        }

        private async Task<bool> IfPatientIsAssignToLoggedDoctor(PatientDataCheckUpViewModel model)
            => (await _patientService.GetPatient(_configuration["Paths:GetPatientByPesel"] 
                + model.PatientPesel, HttpContext.Session.GetString("token"))).IdOfSelectedDoctor == model.DoctorId;
    }
}
