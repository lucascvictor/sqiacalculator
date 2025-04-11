using Moq;
using SQIACalculator.Domain.Commons;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Tests
{
    public class CotacaoTests
    {
        private readonly Mock<ICotacaoRepository> _mockCotacaoRepository;
        private readonly Cotacao _cotacao;

        public CotacaoTests()
        {
            _mockCotacaoRepository = new Mock<ICotacaoRepository>();
            _cotacao = new Cotacao(_mockCotacaoRepository.Object);
        }

        [Fact]
        public void CriarComTaxaAnual_DeveConverterCorretamenteParaTaxaDiaria()
        {
            double taxaAnual = 13.65;
            DateTime diaAnterior = new(2025, 1, 10);

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 1, 9), Indexadores.SQI))
                .Returns(new Cotacao { Valor = 13.65 });

            var cotacao = _cotacao.EncontrarCotacaoDiaria(diaAnterior);

            Assert.Equal(taxaAnual, cotacao);
        }
    }
}
