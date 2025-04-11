using SQIACalculator.Domain.Entities;

namespace SQIACalculator.Domain.Interfaces
{
    public interface ICotacaoRepository
    {
        Cotacao GetByDataEIndexador(DateTime data, string indexador);
    }
}
