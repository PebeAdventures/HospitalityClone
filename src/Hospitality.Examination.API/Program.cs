using Hospitality.Examination.API.Mapper.Profiles;
using Hospitality.Examination.API.Model;
using Hospitality.Examination.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ExaminationContext>(options => options
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Examination_Dev;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExaminationService, ExaminationService>();
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