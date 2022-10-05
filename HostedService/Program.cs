using HostedService;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.
    AddEnvironmentVariables(prefix: "HOSTED_");
builder.Services.AddControllers();
builder.Services.AddTransient<IExaminationPublisher, ExaminationPublisher>();
builder.Services.AddHostedService<ExaminationConsumer>();
builder.Services.AddTransient<IExaminationExecution, ExaminationExecution>();
var app = builder.Build();
app.Run();