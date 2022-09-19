using HostedService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<IExaminationPublisher, ExaminationPublisher>();
builder.Services.AddHostedService<ExaminationConsumer>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
