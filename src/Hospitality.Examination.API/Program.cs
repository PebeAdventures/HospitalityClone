using Hospitality.Examination.API.Model;
using Hospitality.Examination.API.Services;
using Hospitality.Examination.Application;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Application.Mapper.Profiles;
using Hospitality.Examination.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddDbContext<ExaminationContext>(options => options
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Examination_Dev;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExaminationService, ExaminationService>();
builder.Services.AddScoped<IExaminationRepository, ExaminationRepository>();
builder.Services.AddScoped<IExaminationTypesRepository, ExaminationTypesRepository>();
builder.Services.AddAutoMapper(typeof(ExaminationProfile));

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