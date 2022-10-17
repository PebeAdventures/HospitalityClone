using HostedService;
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

builder.Configuration.
    AddEnvironmentVariables(prefix: "HOSTED_");
builder.Services.AddControllers();
//builder.Services.AddTransient<IExaminationPublisher, ExaminationPublisher>();
//builder.Services.AddHostedService<ExaminationConsumer>();
builder.Services.AddTransient<IExaminationExecution, ExaminationExecution>();
var app = builder.Build();
app.Run();