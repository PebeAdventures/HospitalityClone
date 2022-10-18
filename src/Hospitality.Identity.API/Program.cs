using HealthChecks.UI.Client;
using Hospitality.Identity.API.Services.Interfaces;
using Hospitality.Identity.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Hospitality.Identity.API.Services;
using System.Text;
using AutoMapper;
using Hospitality.Identity.API.Profiles;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;


var builder = WebApplication.CreateBuilder(args);

//var builder = WebApplication.CreateBuilder(new WebApplicationOptions
//{
//    Args = args,
//    ApplicationName = typeof(Program).Assembly.FullName,
//    WebRootPath = "customwwwroot"
//});
//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    var settings = config.Build();

//    config.AddAzureAppConfiguration(options =>
//    {
//        options.Connect(settings["ConnectionStrings:AppConfig"])
//                .ConfigureKeyVault(kv =>
//                {
//                    kv.SetCredential(new DefaultAzureCredential());
//                });
//    });
//});
//Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
//Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");




builder.Configuration.
    AddEnvironmentVariables(prefix: "IDENTITY_");

var kvUrl = builder.Configuration["AzureKeyVaultUri"];
var secretsClient = new SecretClient(new Uri(kvUrl), new DefaultAzureCredential());
var sqlConnectionString = secretsClient.GetSecret("connectionstring").Value.Value;

builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(sqlConnectionString));


//builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("IDENTITY_SQL_CONNECTONSTRING")));
//builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetValue<string>("IDENTITY_SQL_CONNECTONSTRING"));

//builder.Services.AddDbContext<IdentityContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("AzureDb")));
//builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("AzureDb"));

//builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("AzureDb")));
builder.Services.AddHealthChecks().AddSqlServer(sqlConnectionString);


builder.Services.AddScoped<ILogInService, LogInServicert>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
var mapConfig = new MapperConfiguration(c =>
{
    c.AddProfile(new UserModelProfile());
});

var mapper = mapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 2;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddCors(o => o.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
if (app.Environment.EnvironmentName != "Local")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<IdentityContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}
app.Run();