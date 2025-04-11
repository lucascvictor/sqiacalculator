using System.Text.Json.Serialization;

namespace SQIACalculator.Domain.DTOs
{
    public class ResultadoPosFixadoDTO(decimal fatorAcumulado, decimal valorFinal)
    {
        [JsonPropertyName("fatorAcumulado")]
        public decimal FatorAcumulado { get; set; } = fatorAcumulado;

        [JsonPropertyName("valorFinal")]
        public decimal ValorFinal { get; set; } = valorFinal;
    }
}
