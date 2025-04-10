namespace SQIACalculator.Domain.DTOs
{
    public class ResultadoDTO(decimal fatorAcumulado, decimal valorFinal)
    {
        public decimal FatorAcumulado { get; set; } = fatorAcumulado;
        public decimal ValorFinal { get; set; } = valorFinal;
    }
}
