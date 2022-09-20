using EmailService.EmailHostedService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHostedService<EmailHostedServiceConsumer>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
