using Hospitality.Examination.API.Model;
using Hospitality.Examination.Application;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Application.Mapper.Profiles;
using Hospitality.Examination.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Hospitality.Examination.API.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddDbContext<ExaminationContext>(options => options
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Examination_Dev;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExaminationRepository, ExaminationRepository>();
builder.Services.AddScoped<IExaminationTypesRepository, ExaminationTypesRepository>();
builder.Services.AddScoped<IRabbitMqService, RabbitMQPublisher>();
builder.Services.AddHostedService<RabbitMQConsumer>();



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