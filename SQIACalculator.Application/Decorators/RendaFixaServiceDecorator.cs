using Microsoft.Extensions.Logging;
using SQIACalculator.Domain.DTOs;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Application.Decorators
{
    public class RendaFixaServiceDecorator : IRendaFixaService
    {
        private readonly IRendaFixaService _inner;
        private readonly ILogger<RendaFixaServiceDecorator> _logger;

        public RendaFixaServiceDecorator(
            IRendaFixaService inner,
            ILogger<RendaFixaServiceDecorator> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public ResultadoPosFixadoDTO CalcularIndexadorPosFixado(ConsultaPosFixadoDTO input)
        {
            _logger.LogInformation("Início do cálculo com input: {@Input}", input);

            try
            {
                var resultado = _inner.CalcularIndexadorPosFixado(input);
                _logger.LogInformation("Cálculo concluído com sucesso. Resultado: {@Resultado}", resultado);
                return resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao calcular rendimento.");
                throw;
            }
        }
    }
}
