using SQIACalculator.Infrastructure;
using SQIACalculator.Application;
using SQIACalculator.API.Validators;

var builder = WebApplication.CreateBuilder(args);

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
