using Microsoft.Extensions.Logging;
using Moq;
using SQIACalculator.Application.Services;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.Tests
{
    public class JurosServiceTests
    {
        private readonly Mock<ICotacaoRepository> _mockCotacaoRepository;
        private readonly Mock<ILogger<JurosService>> _mockLogger;
        private readonly JurosService _jurosService;

        public JurosServiceTests()
        {
            _mockCotacaoRepository = new Mock<ICotacaoRepository>();
            _mockLogger = new Mock<ILogger<JurosService>>();
            _jurosService = new JurosService(_mockCotacaoRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public void CalcularJurosCompostos_DeveRetornarValorCorreto()
        {
            // Arrange
            decimal valorInicial = 10000;
            DateTime dataInicio = new(2025, 3, 13);
            DateTime dataFim = new(2025, 3, 21);

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 13), "SQI"))
                .Returns(new Cotacao { Valor = 12 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 14), "SQI"))
                .Returns(new Cotacao { Valor = 12.5 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 17), "SQI"))
                .Returns(new Cotacao { Valor = 11 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 18), "SQI"))
                .Returns(new Cotacao { Valor = 12.2 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 19), "SQI"))
                .Returns(new Cotacao { Valor = 13 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 20), "SQI"))
                .Returns(new Cotacao { Valor = 12.4 });

            _mockCotacaoRepository.Setup(repo => repo.GetByDataEIndexador(new DateTime(2025, 3, 21), "SQI"))
                .Returns(new Cotacao { Valor = 12.7 });

            // Act
            var resultado = _jurosService.CalcularJurosCompostos(valorInicial, dataInicio, dataFim);

            // Assert
            Assert.Equal(10027.40m, resultado.ValorFinal);
            Assert.Equal(1.0027406373002737670937490725m, resultado.FatorAcumulado);
        }
    }
}
