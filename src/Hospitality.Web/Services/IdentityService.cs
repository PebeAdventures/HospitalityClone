using Hospitality.Common.DTO.Registration;
using Hospitality.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Hospitality.Web.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private HttpClient _httpClient;
        public IdentityService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<DoctorDTO>> GetAllDoctorsNamesAndIds(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var link = _configuration["Paths:GetAllDoctorsNamesAndIds"];
            var response = await _httpClient.GetAsync(link);
            var responseAsync = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DoctorDTO>>(responseAsync);
        }
        public async Task<Guid> GetIdOfSelectedDoctor(string nameOfSelectedDoctor, string token)
            => (await GetAllDoctorsNamesAndIds(token)).FirstOrDefault(d => d.Name == nameOfSelectedDoctor).Id;
    }
}
