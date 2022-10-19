using Hospitality.Common.DTO.Temperature;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PatientTemperatureControl.Models;

namespace PatientTemperatureControl.Services
{
    public class TemperaturesService : ITemperaturesService
    {
        private readonly IMongoCollection<PatientTemperature> _temperaturesCollection;
        private readonly IConfiguration _configuration;

        public TemperaturesService(IOptions<PatientTemperaturesDatabaseSettings> temperaturesDatabaseSettings, IConfiguration configuration)
        {
            _configuration = configuration;
            var mongoClient = new MongoClient(_configuration["cosmos--connectionstring"]);

            var mongoDatabase = mongoClient.GetDatabase(temperaturesDatabaseSettings.Value.DatabaseName);

            _temperaturesCollection = mongoDatabase.GetCollection<PatientTemperature>(
                temperaturesDatabaseSettings.Value.TemperaturesCollectionName);
        }

        public async Task<List<PatientTemperaturesViewDTO>> GetAllPatientTemperatures(string id)
        {
            List<PatientTemperaturesViewDTO> patientTemperaturesViewDTO = new();
            List<PatientTemperature> patientTemperatures = await _temperaturesCollection.Find(x => x.PatientId == id).ToListAsync();
            foreach (var patientTemperature in patientTemperatures)
            {
                patientTemperaturesViewDTO.Add(new PatientTemperaturesViewDTO() { PatientId = patientTemperature.PatientId, Temperature = patientTemperature.Temperature, MeasurementDate = patientTemperature.MeasurementDate });
            }
            return patientTemperaturesViewDTO;
        }

        public async Task AddNewPatientTemperature(NewPatientTemperatureDTO newPatientTemperatureDTO)
        {

            var date = DateTime.UtcNow;

            await _temperaturesCollection.InsertOneAsync(new PatientTemperature()
            {
                PatientId = newPatientTemperatureDTO.PatientId,
                Temperature = newPatientTemperatureDTO.Temperature,
                MeasurementDate = date
            });
        }
    }
}