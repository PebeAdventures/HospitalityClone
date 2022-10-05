using Hospitality.Patient.API.Data.Context;
using Hospitality.Patient.API.Mapper;
using Hospitality.Patient.API.PatientHostedService;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables(prefix: "PATIENT_");

builder.Services.AddDbContext<PatientContext>(options => options
    .UseSqlServer(builder.Configuration.GetValue<string>("PATIENT_SQL_CONNECTONSTRING")), ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddCustomServices();
builder.Services.AddControllers();
builder.Services.AddHostedService<PatientHostedServiceConsumer>();

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

app.UseCustomMiddlewares();

app.UseCors();

app.Run();