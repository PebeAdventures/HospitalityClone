using Hospitality.CheckUp.API.DataBase.Context;
using Hospitality.CheckUp.API.Extensions;
using Hospitality.CheckUp.API.Middlewares;
using Hospitality.CheckUp.API.Service;
using Hospitality.CheckUp.API.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddScoped<ICheckUpService, CheckUpService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CheckUpContext>(builder =>
{
    builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CheckUp;Integrated Security=True");
});

builder.Services.AddCustomCors();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseCors();
app.MapControllers();

app.Run();
