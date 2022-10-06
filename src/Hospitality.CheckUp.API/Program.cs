using Hospitality.CheckUp.API.DataBase.Context;
using Hospitality.CheckUp.API.Extensions;
using Hospitality.CheckUp.API.Service;
using Hospitality.CheckUp.API.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables(prefix: "CHECKUP_");

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddScoped<ICheckUpService, CheckUpService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();