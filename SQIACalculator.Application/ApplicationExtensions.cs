using Microsoft.Extensions.DependencyInjection;
using SQIACalculator.Application.Services;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Application
{
    public static class ApplicationExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddScoped<IRendaFixaService, RendaFixaService>();
        }
    }
}
