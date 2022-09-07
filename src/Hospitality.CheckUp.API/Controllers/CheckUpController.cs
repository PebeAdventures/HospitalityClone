using Hospitality.CheckUp.API.Service.Interface;
using Hospitality.Common.DTO.CheckUp;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospitality.CheckUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUpController : ControllerBase
    {

        private readonly ICheckUpService _checkUpService;
        private readonly HttpClient _httpClient;
        public CheckUpController(ICheckUpService checkUpService, HttpClient httpClient)
        {
            _checkUpService = checkUpService;
            _httpClient = httpClient;
        }

        /*  private async Task<ContentResult> ProxyTo(string url, string value)
          {

              var content = new StringContent(value, Encoding.UTF8, "application/json");
              var respond = await _httpClient.PostAsync(url, content);
              var result = await respond.Content.ReadAsStringAsync();
              return Content(result);

          }


          [HttpPost]
          [Route("/bubble")]
          public async Task<IActionResult> Bubble([FromBody] List<int> list)
          {
              var jsonstring = JsonConvert.SerializeObject(list);
              return await ProxyTo("http://algdataapi.algorithm/bubble", jsonstring);
          }*/
        // POST api/<CheckUpController>
        [HttpPost]
        public void AddNewCheckUp([FromBody] NewCheckUpDTO newCheckUpDTO)
        {

        }

    }
}
