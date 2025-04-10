namespace SQIACalculator.Domain.Entities
{
    public class Resultado
    {
        public Resultado(decimal fatorAcumulado, decimal valorFinal)
        {
            FatorAcumulado = fatorAcumulado;
            ValorFinal = valorFinal;
        }

        public decimal FatorAcumulado { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
