using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Application.Functions.Examinations.Commands;
using Hospitality.Examination.Application.Functions.Examinations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using Hospitality.Examination.RabbitMQ;
using Hospitality.Examination.Domain.Entities.Enums;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;

namespace Hospitality.Examination.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRabbitMqService _mqService;


        public ExaminationController(IMediator mediator, IRabbitMqService mqService)
        {
            _mediator = mediator;
            _mqService = mqService;
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetExaminationById(int id)
        => Ok(await _mediator.Send(new GetExaminationByIdQuery() { ExaminationId = id }));

        [HttpGet("PatientId")]
        public async Task<IActionResult> GetPatientExaminations(int patientId)
        => Ok(await _mediator.Send(new GetPatientExaminationsQuery() { PatientId = patientId }));

        [HttpPost]
        public async Task<IActionResult> AddNewExamination(CreateExaminationDto examinationDto)
        {
            var examination = await _mediator.Send(new AddNewExaminationCommand()
            {
                Status = (int)ExaminationStatus.InProgress,
                ExaminationTypeId = examinationDto.ExaminationTypeId,
                PatientId = examinationDto.PatientId,
                Description = ""
               
            });
            aaa(examinationDto);
            return CreatedAtAction("GetExaminationById", new { id = examination.Id }, examination);
        }


        public void aaa(CreateExaminationDto examinationDto)
        {
            //Create PDF Document
            PdfDocument document = new PdfDocument();
            //You will have to add Page in PDF Document
            PdfPage page = document.AddPage();
            //For drawing in PDF Page you will nedd XGraphics Object
            XGraphics gfx = XGraphics.FromPdfPage(page);
            //For Test you will have to define font to be used
            XFont font = new XFont("Verdana", 10, XFontStyle.Regular);
            XFont headerFont = new XFont("Verdana", 15, XFontStyle.Bold);

            //Finally use XGraphics & font object to draw text in PDF Page
            string text = "".PadRight(50)+"FAKTURA NR: 23058173475\n" +"SPRZEDAWCA".PadRight(20) + "NABYWCA\n" + "Hospitality Sp. z o.o.".PadRight(20) + "Patient name\n" +
                            "Czerwone Maki 82,".PadRight(20) + "Address,\n" +  "30 -392 Kraków\n NIP: 525-15-77-627\n\n\n\n\n" + "Usługi medyczne: Nazwa \n" + "Wyniki: \n Cena:\n";
            

            gfx.DrawString("FAKTURA NR: 23058173475", headerFont, XBrushes.Black, new XRect(0, 50, page.Width, page.Height), XStringFormats.TopRight);
            gfx.DrawString("SPRZEDAWCA", headerFont, XBrushes.Black, new XRect(20, 70, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"NABYWCA:{examinationDto.PatientId}", headerFont, XBrushes.Black, new XRect(0, 70, page.Width, page.Height), XStringFormats.TopRight);
            gfx.DrawString("Usługi medyczne: Nazwa \nWyniki: \n Cena:\n", font, XBrushes.Black, new XRect(10, 100, page.Width, page.Height), XStringFormats.TopLeft);



            //Specify file name of the PDF file
            string filename = "FirstPDFDocument.pdf";
            //Save PDF File
            document.Save(filename);
            //Load PDF File for viewing
            Process.Start(filename);
        }
    }
}