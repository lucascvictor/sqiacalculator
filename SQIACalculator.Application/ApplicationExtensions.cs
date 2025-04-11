using Microsoft.Extensions.DependencyInjection;
using SQIACalculator.Application.Decorators;
using SQIACalculator.Application.Services;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Application
{
    public static class ApplicationExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddScoped<IRendaFixaService, RendaFixaService>();
            services.AddScoped<IRendaFixa, RendaFixa>();
            services.AddScoped<ICotacao, Cotacao>();
            services.Decorate<IRendaFixaService, RendaFixaServiceDecorator>();
        }
    }
}
