using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using PatientTemperatureControl.Models;
using PatientTemperatureControl.Services;

var builder = WebApplication.CreateBuilder(args);

string kvURL = builder.Configuration["KeyVaultConfig:KVUrl"];
string tenantId = builder.Configuration["KeyVaultConfig:TenantId"];
string clientId = builder.Configuration["KeyVaultConfig:ClientId"];
string clientSecret = builder.Configuration["KeyVaultConfig:ClientSecretId"];

var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

var client = new SecretClient(new Uri(kvURL), credential);

builder.Configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());

builder.Configuration.
    AddEnvironmentVariables(prefix: "MONGO_");
builder.Services.Configure<PatientTemperaturesDatabaseSettings>(
    builder.Configuration.GetSection("TemperatureDatabase"));

builder.Services.AddSingleton<ITemperaturesService, TemperaturesService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();