using Hospitality.Patient.API.Data.Context;
using Hospitality.Patient.API.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PatientContext>(options => options
    .UseSqlServer(builder.Configuration["ConnectionStrings:PatientDbDocker"]));

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

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PatientContext>();
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