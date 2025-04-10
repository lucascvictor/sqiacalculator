using SQIACalculator.Infrastructure;
using SQIACalculator.Application;
using SQIACalculator.API.Validators;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    // .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) -- Utilizei este log para avalia��o fora da execu��o do console
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.ConfigureInfraApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.AddFluentValidationValidators();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
