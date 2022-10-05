using HealthChecks.UI.Client;
using Hospitality.Examination.API.Extensions;
using Hospitality.Examination.API.Model;
using Hospitality.Examination.Application;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.
    AddEnvironmentVariables(prefix: "EXAMINATION_");
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddDbContext<ExaminationContext>(options => options
    .UseSqlServer(builder.Configuration.GetValue<string>("EXAMINATION_SQL_CONNECTONSTRING")), ServiceLifetime.Transient, ServiceLifetime.Transient);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomServices(builder.Configuration);

var app = builder.Build();
if (app.Environment.EnvironmentName != "Local")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ExaminationContext>();
        context.Database.Migrate();
    }
}
//Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseAuthorization();

app.UseCustomMiddlewares();

app.UseCors();

app.MapControllers();

app.Run();