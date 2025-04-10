using FluentValidation;
using FluentValidation.AspNetCore;

namespace SQIACalculator.API.Validators
{
    public static class ValidatorRegistrationService
    {
        public static IServiceCollection AddFluentValidationValidators(this IServiceCollection services)
        {
            return services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssemblyContaining<PosFixadoValidator>();
        }
    }
}
