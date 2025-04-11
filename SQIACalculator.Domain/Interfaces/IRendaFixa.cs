using SQIACalculator.Domain.DTOs;

namespace SQIACalculator.Domain.Interfaces
{
    public interface IRendaFixa
    {
        decimal CalcularFatorAcumulado(ConsultaPosFixadoDTO consulta);
    }
}
