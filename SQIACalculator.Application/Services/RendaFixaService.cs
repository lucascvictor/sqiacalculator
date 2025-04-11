using SQIACalculator.Domain.DTOs;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Application.Services
{
    public class RendaFixaService(IRendaFixa rendaFixa) : IRendaFixaService
    {
        private readonly IRendaFixa _rendaFixa = rendaFixa;

        public ResultadoPosFixadoDTO CalcularIndexadorPosFixado(ConsultaPosFixadoDTO consulta)
        {
            decimal fatorAcumulado = _rendaFixa.CalcularFatorAcumulado(consulta);
            decimal valorFinal = Math.Round(consulta.ValorInicial * fatorAcumulado, 2, MidpointRounding.ToZero);

            return new(fatorAcumulado, valorFinal);
        }
    }
}
