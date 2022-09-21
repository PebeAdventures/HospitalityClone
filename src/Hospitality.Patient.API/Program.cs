using Hospitality.Patient.API.Data.Context;
using Hospitality.Patient.API.Mapper;
using Hospitality.Patient.API.PatientHostedService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PatientContext>(builder =>
{
    builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PatientDB;Integrated Security=True");
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddCustomServices();

builder.Services.AddControllers();
builder.Services.AddHostedService<PatientHostedServiceConsumer>();
builder.Services.AddTransient<IPatientHostedServicePublisher, PatientHostedServicePublisher>();
builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IPatientService, PatientService>();

builder.Services.AddCustomCors();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapConfig = new MapperConfiguration(c =>
{
    c.AddProfile(new PatientProfile());
});

var mapper = mapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
