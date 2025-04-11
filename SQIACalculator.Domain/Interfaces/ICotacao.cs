using SQIACalculator.Domain.Entities;

namespace SQIACalculator.Domain.Interfaces
{
    public interface ICotacao
    {
        double EncontrarCotacaoDiaria(DateTime data);
    }
}
