using System.Text.Json.Serialization;

namespace SQIACalculator.Domain.DTOs
{
    public class ConsultaPosFixadoDTO
    {
        [JsonPropertyName("valorInicial")]
        public decimal ValorInicial { get; set; }

        [JsonPropertyName("dataInicial")]
        public DateTime DataInicial { get; set; }

        [JsonPropertyName("dataFinal")]
        public DateTime DataFinal { get; set; }
    }
}
