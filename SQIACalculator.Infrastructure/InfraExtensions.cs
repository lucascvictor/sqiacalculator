using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQIACalculator.Domain.Interfaces;
using SQIACalculator.Infrastructure.Context;
using SQIACalculator.Infrastructure.Repositories;

namespace SQIACalculator.Infrastructure
{
    public static class InfraExtensions
    {
        public static void ConfigureInfraApp(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<ICotacaoRepository, CotacaoRepository>();
        }
    }
}
