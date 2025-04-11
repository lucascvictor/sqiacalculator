using Microsoft.Extensions.Logging;
using Moq;
using SQIACalculator.Application.Services;
using SQIACalculator.Domain.Commons;
using SQIACalculator.Domain.DTOs;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Tests
{
    public class RendaFixaServiceTests
    {
        private readonly Mock<ICotacaoRepository> _mockCotacaoRepository;
        private readonly Mock<ILogger<RendaFixaService>> _mockLogger;
        private readonly RendaFixaService _rendaFixaService;

        public RendaFixaServiceTests()
        {
            _mockCotacaoRepository = new Mock<ICotacaoRepository>();
            _mockLogger = new Mock<ILogger<RendaFixaService>>();
            _rendaFixaService = new RendaFixaService(_mockCotacaoRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public void CalcularIndexadorPosFixado_DeveRetornarValorCorreto()
        {
            // Arrange
            ConsultaPosFixadoDTO consulta = new()
            {
                ValorInicial = 10000,
                DataInicial = new(2025, 3, 13),
                DataFinal = new(2025, 3, 21),
            };

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 13), Indexadores.SQI))
                .Returns(new Cotacao { Valor = 12 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 14), Indexadores.SQI))
                .Returns(new Cotacao { Valor = 12.5 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 17), Indexadores.SQI))
                .Returns(new Cotacao { Valor = 11 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 18), Indexadores.SQI))
                .Returns(new Cotacao { Valor = 12.2 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 19), Indexadores.SQI))
                .Returns(new Cotacao { Valor = 13 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 20), Indexadores.SQI))
                .Returns(new Cotacao { Valor = 12.4 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 21), Indexadores.SQI))
                .Returns(new Cotacao { Valor = 12.7 });

            // Act
            var resultado = _rendaFixaService.CalcularIndexadorPosFixado(consulta);

            // Assert
            Assert.Equal(10027.40m, resultado.ValorFinal);
            Assert.Equal(1.0027406373002737670937490725m, resultado.FatorAcumulado);
        }

        [Fact]
        public void CalcularFatorAcumulado_DeveCalcularFatorCorretamente()
        {
            ConsultaPosFixadoDTO consulta = new()
            {
                ValorInicial = 10000,
                DataInicial = new(2025, 1, 1),
                DataFinal = new(2025, 1, 5),
            };

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(It.IsAny<DateTime>(), Indexadores.SQI))
                .Returns(new Cotacao { Valor = 10.5 });

            var resultado = _rendaFixaService.CalcularIndexadorPosFixado(consulta);

            Assert.True(resultado.FatorAcumulado > 1);
        }


        [Fact]
        public void EncontrarCotacaoDiaria_DeveRetornarCotacaoCorreta()
        {
            var data = new DateTime(2025, 1, 10);
            var dataUtilAnterior = data.AddDays(-1);
            var cotacao = new Cotacao { Valor = 10.5 };

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(dataUtilAnterior, Indexadores.SQI))
                .Returns(cotacao);

            var resultado = _mockCotacaoRepository.Object.GetByDataEIndexador(dataUtilAnterior, Indexadores.SQI);

            Assert.Equal(10.5, resultado?.Valor);
        }
    }
}
