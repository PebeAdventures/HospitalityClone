using Hospitality.Examination.API.Extensions;
using Hospitality.Examination.API.Model;
using Hospitality.Examination.Application;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Application.Mapper.Profiles;
using Hospitality.Examination.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Hospitality.Examination.Application.Services;
using Hospitality.Examination.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddDbContext<ExaminationContext>(options => options
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Examination_Dev;Trusted_Connection=True;MultipleActiveResultSets=true"), ServiceLifetime.Transient, ServiceLifetime.Transient);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExaminationRepository, ExaminationRepository>();
builder.Services.AddScoped<IExaminationTypesRepository, ExaminationTypesRepository>();
builder.Services.AddAutoMapper(typeof(ExaminationProfile));

builder.Services.AddCustomCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();