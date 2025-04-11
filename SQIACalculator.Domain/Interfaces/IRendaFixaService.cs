using SQIACalculator.Domain.DTOs;

namespace SQIACalculator.Domain.Interfaces
{
    public interface IRendaFixaService
    {
        ResultadoPosFixadoDTO CalcularIndexadorPosFixado(ConsultaPosFixadoDTO consulta);
    }
}
