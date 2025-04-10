using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Application.Services
{
    public class JurosService : IJurosService
    {
        private readonly ICotacaoRepository _cotacaorepository;

        public JurosService(ICotacaoRepository cotacaoRepository)
        {
            _cotacaorepository = cotacaoRepository;
        }

        public Resultado CalcularJurosCompostos(decimal valorInicial, DateTime dataInicio, DateTime dataFim)
        {
            decimal fatorAcumulado = CalcularFatorAcumulado(dataInicio, dataFim, valorInicial);
            decimal valorFinal = Math.Round((decimal)valorInicial * fatorAcumulado, 2, MidpointRounding.ToZero);
            Resultado resultado = new(fatorAcumulado, valorFinal);

            return resultado;
        }

        private decimal CalcularFatorAcumulado(DateTime inicio, DateTime fim, decimal valorInicial)
        {
            decimal fatorAcumulado = 1;

            for (var data = inicio; data <= fim; data = data.AddDays(1))
            {
                if (!data.Equals(inicio) && data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday)
                {
                    fatorAcumulado *= DefinirFatorDiario(data);
                }
                Console.WriteLine("Fator Acumulado: " + fatorAcumulado);
                decimal valorAtualizado = Math.Round(valorInicial * fatorAcumulado, 2, MidpointRounding.ToZero);
                Console.WriteLine("Valor atualizado: " + valorAtualizado);
                Console.WriteLine("_______________________________________________________________________________");
            }

            return fatorAcumulado;
        }

        private decimal DefinirFatorDiario(DateTime data)
        {
            Cotacao? cotacao = EncontrarCotacaoDiaria(data);
            return cotacao != null && cotacao.Valor != default ? CalcularFatorDiario(cotacao.Valor) : 0;
        }

        private Cotacao? EncontrarCotacaoDiaria(DateTime data)
        {
            DateTime diaUtilAnterior = EncontrarDiaUtilAnterior(data);
            Console.WriteLine("Dia Util Anterior: " + diaUtilAnterior);


            Cotacao? cotacao = _cotacaorepository.GetByDataEIndexador(diaUtilAnterior, "SQI");
            Console.WriteLine("Cotacao: " + cotacao?.Valor);

            return cotacao;
        }

        private static DateTime EncontrarDiaUtilAnterior(DateTime data)
        {
            DateTime diaAnterior = data.AddDays(-1);

            while (diaAnterior.DayOfWeek == DayOfWeek.Saturday || diaAnterior.DayOfWeek == DayOfWeek.Sunday)
                diaAnterior = diaAnterior.AddDays(-1);

            return diaAnterior;
        }

        private static decimal CalcularFatorDiario(double taxaAnual)
        {
            decimal fatorDiario = Math.Round((decimal)Math.Pow(1 + (taxaAnual / 100), 1.0 / 252), 16);
            Console.WriteLine("Fator Diário: " + Math.Round(fatorDiario, 8, MidpointRounding.ToZero));
            return fatorDiario;
        }
    }
}
