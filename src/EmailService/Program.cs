using EmailService.EmailHostedService;
using EmailService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHostedService<EmailHostedServiceConsumer>();

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddTransient<IEmailSender, EmailSender>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
