using EmailService.EmailHostedService;
using EmailService;
using EmailService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHostedService<EmailHostedServiceConsumer>();

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddCustomCors();
var app = builder.Build();
app.UseCors();
app.Run();