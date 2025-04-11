using Microsoft.Extensions.Logging;
using SQIACalculator.Domain.Commons;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Infrastructure.Decorators
{
    public class CotacaoRepositoryDecorator : ICotacaoRepository
    {
        private readonly ICotacaoRepository _inner;
        private readonly ILogger<CotacaoRepositoryDecorator> _logger;

        public CotacaoRepositoryDecorator(
            ICotacaoRepository inner,
            ILogger<CotacaoRepositoryDecorator> logger)
        {
            _inner = inner;
            _logger = logger;

        }

        public Cotacao GetByDataEIndexador(DateTime data, string indexador)
        {
            _logger.LogInformation("Cotação para a data: {data}", data);

            try
            {
                var resultado = _inner.GetByDataEIndexador(data, indexador);
                var fatorDiario = Calculos.FatorDiario(resultado.Valor);

                _logger.LogInformation("Cotação: {@Resultado}", resultado);
                _logger.LogInformation("Fator diário: {fatorDiario}", fatorDiario);

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
