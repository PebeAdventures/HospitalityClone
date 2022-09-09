using Hospitality.CheckUp.API.DataBase.Context;
using Hospitality.CheckUp.API.Service;
using Hospitality.CheckUp.API.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CheckUpContext>(builder =>
{
    builder.UseSqlServer(@"Server=checkupdb;Database=dbcheckup;User Id=sa;Password=Pass@word;Integrated Security=True");
});
builder.Services.AddScoped<ICheckUpService, CheckUpService>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CheckUpContext>();
    context.Database.Migrate();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
