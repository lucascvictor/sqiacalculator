using Microsoft.Extensions.DependencyInjection;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Domain
{
    public static class DomainExtensions
    {
        public static void ConfigureDomainApp(this IServiceCollection services)
        {
            services.AddScoped<IRendaFixa, RendaFixa>();
            services.AddScoped<ICotacao, Cotacao>();
        }
    }
}
