using SQIACalculator.Domain.Entities;

namespace SQIACalculator.Domain.Interfaces
{
    public interface ICotacaoRepository
    {
        Task<Cotacao> GetByValorEIntervalo(double valorInicial, DateTime dataInicio, DateTime dataFim);
    }
}
