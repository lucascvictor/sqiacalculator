using SQIACalculator.Domain.Entities;

namespace SQIACalculator.Domain.Interfaces
{
    public interface IJurosService
    {
        Resultado CalcularJurosCompostos(decimal valorInicial, DateTime dataInicio, DateTime dataFim);
    }
}
