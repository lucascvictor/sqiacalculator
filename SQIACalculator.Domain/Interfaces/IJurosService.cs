using SQIACalculator.Domain.DTOs;

namespace SQIACalculator.Domain.Interfaces
{
    public interface IJurosService
    {
        ResultadoDTO CalcularJurosCompostos(decimal valorInicial, DateTime dataInicio, DateTime dataFim);
    }
}
