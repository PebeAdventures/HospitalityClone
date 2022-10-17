using HealthChecks.UI.Client;
using Hospitality.CheckUp.API.DataBase.Context;
using Hospitality.CheckUp.API.Extensions;
using Hospitality.CheckUp.API.Service;
using Hospitality.CheckUp.API.Service.Interface;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);
var kvUrl = builder.Configuration["VaultUri"];
var secretClient = new SecretClient(new Uri(kvUrl), new DefaultAzureCredential());
var sqlConnectionString = secretClient.GetSecret("checkupDB").Value.Value;

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
builder.Configuration.AddEnvironmentVariables(prefix: "CHECKUP_");

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddScoped<ICheckUpService, CheckUpService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetValue<string>("CHECKUP_SQL_CONNECTONSTRING"));

builder.Services.AddDbContext<CheckUpContext>(options => options
    .UseSqlServer(builder.Configuration.GetValue<string>("CHECKUP_SQL_CONNECTONSTRING")), ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddCustomCors();
var app = builder.Build();
if (app.Environment.EnvironmentName != "Local")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<CheckUpContext>();
        context.Database.Migrate();
    }
}
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();