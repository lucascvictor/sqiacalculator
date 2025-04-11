using Moq;
using SQIACalculator.Domain.DTOs;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Tests
{
    public class RendaFixaTests
    {
        private readonly Mock<ICotacaoRepository> _mockCotacaoRepository;
        private readonly Cotacao _cotacao;
        private readonly RendaFixa _rendaFixa;

        public RendaFixaTests()
        {
            _mockCotacaoRepository = new Mock<ICotacaoRepository>();
            _cotacao = new Cotacao(_mockCotacaoRepository.Object);
            _rendaFixa = new RendaFixa(_cotacao);
        }


        [Fact]
        public void Criar_DeveIgualarAUmPorFaltaDeCotacoes()
        {

            ConsultaPosFixadoDTO consulta = new()
            {
                ValorInicial = 10000,
                DataInicial = new(2024, 3, 13),
                DataFinal = new(2024, 3, 21),
            };

            var resposta = _rendaFixa.CalcularFatorAcumulado(consulta);

            Assert.Equal(1, resposta);
        }
    }
}
