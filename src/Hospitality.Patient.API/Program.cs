using Hospitality.Patient.API.Data.Context;
using Hospitality.Patient.API.Mapper;
using Hospitality.Patient.API.PatientHostedService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PatientContext>(options => options
    .UseSqlServer(builder.Configuration["PatientDb"]));

builder.Services.AddCustomServices();

builder.Services.AddControllers();
//builder.Services.AddHostedService<PatientHostedServiceConsumer>();
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
if (app.Environment.EnvironmentName != "Local")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<PatientContext>();
        context.Database.Migrate();
    }
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
