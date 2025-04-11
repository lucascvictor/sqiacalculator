using SQIACalculator.Domain.Commons;
using SQIACalculator.Domain.DTOs;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Application.Services
{
    public class RendaFixaService(ICotacaoRepository cotacaoRepository) : IRendaFixaService
    {
        private readonly ICotacaoRepository _cotacaoRepository = cotacaoRepository;

        public ResultadoPosFixadoDTO CalcularIndexadorPosFixado(ConsultaPosFixadoDTO consulta)
        {
            decimal fatorAcumulado = CalcularFatorAcumulado(consulta);
            decimal valorFinal = Math.Round(consulta.ValorInicial * fatorAcumulado, 2, MidpointRounding.ToZero);

            return new(fatorAcumulado, valorFinal);
        }

        private decimal CalcularFatorAcumulado(ConsultaPosFixadoDTO consulta)
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
            Cotacao? cotacao = EncontrarCotacaoDiaria(data);
            return cotacao != null && cotacao.Valor != default ? Calculos.FatorDiario(cotacao.Valor) : 1;
        }

        private Cotacao EncontrarCotacaoDiaria(DateTime data)
        {
            DateTime diaUtilAnterior = EncontrarDiaUtilAnterior(data);
            Cotacao cotacao = _cotacaoRepository.GetByDataEIndexador(diaUtilAnterior, Indexadores.SQI);

            return cotacao;
        }

        private static DateTime EncontrarDiaUtilAnterior(DateTime data)
        {
            DateTime diaAnterior = data.AddDays(-1);

            while (diaAnterior.DayOfWeek == DayOfWeek.Saturday || diaAnterior.DayOfWeek == DayOfWeek.Sunday)
                diaAnterior = diaAnterior.AddDays(-1);

            return diaAnterior;
        }
    }
}
