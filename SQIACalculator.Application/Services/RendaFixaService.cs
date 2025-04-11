using Microsoft.Extensions.Logging;
using SQIACalculator.Domain.Commons;
using SQIACalculator.Domain.DTOs;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Application.Services
{
    public class RendaFixaService(ICotacaoRepository cotacaoRepository, ILogger<RendaFixaService> logger) : IRendaFixaService
    {
        private readonly ICotacaoRepository _cotacaoRepository = cotacaoRepository;
        private readonly ILogger _logger = logger;

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
                
                decimal valorAtualizado = Math.Round(consulta.ValorInicial * fatorAcumulado, 2, MidpointRounding.ToZero);

                _logger.LogInformation("Fator acumulado: {fatorAcumulado}", fatorAcumulado);
                _logger.LogInformation("Valor atualizado: {valorAtualizado}", valorAtualizado);
                _logger.LogInformation(new string('_', 40) + "\n");
            }

            return fatorAcumulado;
        }

        private decimal FatorDiario(DateTime data)
        {
            Cotacao? cotacao = EncontrarCotacaoDiaria(data);
            return cotacao != null && cotacao.Valor != default ? CalcularFatorDiario(cotacao.Valor) : 0;
        }

        private Cotacao? EncontrarCotacaoDiaria(DateTime data)
        {
            DateTime diaUtilAnterior = EncontrarDiaUtilAnterior(data);
            Cotacao? cotacao = _cotacaoRepository.GetByDataEIndexador(diaUtilAnterior, Indexadores.SQI);

            _logger.LogInformation("Dia útil anterior: {diaUtilAnterior}", diaUtilAnterior);
            _logger.LogInformation("Cotação: {valor}", cotacao?.Valor);

            return cotacao;
        }

        private static DateTime EncontrarDiaUtilAnterior(DateTime data)
        {
            DateTime diaAnterior = data.AddDays(-1);

            while (diaAnterior.DayOfWeek == DayOfWeek.Saturday || diaAnterior.DayOfWeek == DayOfWeek.Sunday)
                diaAnterior = diaAnterior.AddDays(-1);

            return diaAnterior;
        }

        private decimal CalcularFatorDiario(double taxaAnual)
        {
            decimal fatorDiario = Math.Round((decimal)Math.Pow(1 + (taxaAnual / 100), 1.0 / 252), 16);
            _logger.LogInformation("Fator diário: {valor}", Math.Round(fatorDiario, 8, MidpointRounding.ToZero));
            return fatorDiario;
        }
    }
}
