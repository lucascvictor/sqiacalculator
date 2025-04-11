using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;
using SQIACalculator.Infrastructure.Context;

namespace SQIACalculator.Infrastructure.Repositories
{
    public class CotacaoRepository(AppDbContext appDbContext) : ICotacaoRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public Cotacao GetByDataEIndexador(DateTime data, string indexador)
        {
            var cotacao = _appDbContext.Cotacoes.FirstOrDefault(c => c.Data == data && c.Indexador.Equals(indexador));
            
            cotacao ??= new Cotacao { Data = default, Indexador = string.Empty, Valor = default };

            return cotacao;
        }
    }
}
