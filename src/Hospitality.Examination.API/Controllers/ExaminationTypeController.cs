using Hospitality.Examination.Application.Functions.ExaminationTypes.Queries.GetAllExaminationTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Examination.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExaminationTypeController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("GetAllAvailableExaminationTypes")]
        public async Task<ActionResult> GetAllAvailableExaminationTypes()
            => Ok(await _mediator.Send(new GetAllExaminationTypesQuery()));
    }
}