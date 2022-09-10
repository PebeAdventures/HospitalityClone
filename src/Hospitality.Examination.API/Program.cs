using Hospitality.Examination.API.Model;
using Hospitality.Examination.Application;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Application.Mapper.Profiles;
using Hospitality.Examination.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddDbContext<ExaminationContext>(options => options
    .UseSqlServer("Server=examinationdb;Database=ExaminationDb;User=sa;Password=1Secure*Password1;TrustServerCertificate=true"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExaminationRepository, ExaminationRepository>();
builder.Services.AddScoped<IExaminationTypesRepository, ExaminationTypesRepository>();
builder.Services.AddAutoMapper(typeof(ExaminationProfile));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ExaminationContext>();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();