using SQIACalculator.Domain.Commons;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Domain.Entities
{
    public sealed class Cotacao : Base, ICotacao
    {
        private ICotacaoRepository _cotacaoRepository;

        public DateTime Data { get; set; }
        public string Indexador { get; set; } = null!;
        public double Valor { get; set; }

        public Cotacao()
        {

        }

        public Cotacao(ICotacaoRepository cotacaoRepository)
        {
            _cotacaoRepository  = cotacaoRepository;
        }

        public double EncontrarCotacaoDiaria(DateTime data)
        {
            DateTime diaUtilAnterior = EncontrarDiaUtilAnterior(data);
            Cotacao cotacao = _cotacaoRepository.GetByDataEIndexador(diaUtilAnterior, Indexadores.SQI);

            return cotacao.Valor;
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
