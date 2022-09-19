using Hospitality.Patient.API.Data.Context;
using Hospitality.Patient.API.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PatientContext>(builder =>
{
    builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PatientDB;Integrated Security=True");
});

builder.Services.AddCustomServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapConfig = new MapperConfiguration(c =>
{
    c.AddProfile(new PatientProfile());
});

var mapper = mapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCustomCors();

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
