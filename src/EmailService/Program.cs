using EmailService.EmailHostedService;
using EmailService;
using EmailService.Extensions;
using Microsoft.Extensions.Logging.AzureAppServices;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddAzureWebAppDiagnostics();
builder.Services.Configure<AzureFileLoggerOptions>(options =>
{
    options.FileName = "azure-diagnostics-";
    options.FileSizeLimit = 1000 * 1024;
    options.RetainedFileCountLimit = 5;
});
builder.Services.Configure<AzureBlobLoggerOptions>(options =>
{
    options.BlobName = "log.txt";
});
builder.Services.AddControllers();
builder.Services.AddHostedService<EmailHostedServiceConsumer>();
builder.Configuration.AddEnvironmentVariables(prefix: "EMAIL_");
var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddCustomCors();
var app = builder.Build();
app.UseCors();
app.Run();