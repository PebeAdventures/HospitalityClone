using Hospitality.Examination.Application.Functions.Examinations.Commands;
using Hospitality.Examination.Application.Functions.Examinations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Examination.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExaminationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetExaminationById(int id)
        => Ok(await _mediator.Send(new GetExaminationByIdQuery() { ExaminationId = id }));

        [HttpGet("PatientId")]
        public async Task<IActionResult> GetPatientExaminations(int patientId)
        => Ok(await _mediator.Send(new GetPatientExaminationsQuery() { PatientId = patientId }));

        [HttpPost]
        public async Task<IActionResult> AddNewExamination(AddNewExaminationCommand addPostCommand)
        {
            var examination = await _mediator.Send(addPostCommand);
            return CreatedAtAction("GetExaminationById", new { id = examination.Id }, examination);
        }
    }
}