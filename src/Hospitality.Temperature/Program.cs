using Microsoft.Extensions.Logging.AzureAppServices;
using PatientTemperatureControl.Models;
using PatientTemperatureControl.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddAzureWebAppDiagnostics();
builder.Services.Configure<AzureFileLoggerOptions>(options =>
{
    options.FileName = "azure-diagnostics-";
    options.FileSizeLimit = 1000 * 1024;
    options.RetainedFileCountLimit = 5;
});
builder.Services.Configure<AzureBlobLoggerOptions>(options =>
{
    options.BlobName = "log.txt";
});

// Add services to the container.
builder.Configuration.
    AddEnvironmentVariables(prefix: "MONGO_");
builder.Services.Configure<PatientTemperaturesDatabaseSettings>(
    builder.Configuration.GetSection("TemperatureDatabase"));

builder.Services.AddSingleton<ITemperaturesService, TemperaturesService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();