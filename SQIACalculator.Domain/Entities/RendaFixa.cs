using SQIACalculator.Domain.Commons;
using SQIACalculator.Domain.DTOs;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Domain.Entities
{
    public class RendaFixa(ICotacao cotacao) : IRendaFixa
    {
        private ICotacao _cotacao = cotacao;

        public decimal CalcularFatorAcumulado(ConsultaPosFixadoDTO consulta)
        {
            decimal fatorAcumulado = 1;

            for (var data = consulta.DataInicial; data <= consulta.DataFinal; data = data.AddDays(1))
            {
                if (!data.Equals(consulta.DataInicial) && data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday)
                    fatorAcumulado *= FatorDiario(data);
            }

            return fatorAcumulado;
        }

        private decimal FatorDiario(DateTime data)
        {
            double valor = _cotacao.EncontrarCotacaoDiaria(data);
            return valor != default ? Calculos.FatorDiario(valor) : 1;
        }
    }
}
