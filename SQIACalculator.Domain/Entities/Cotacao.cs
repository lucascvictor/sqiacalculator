namespace SQIACalculator.Domain.Entities
{
    public sealed class Cotacao : Base
    {
        public DateTime Data { get; set; }
        public string Indexador { get; set; } = null!;
        public decimal Valor { get; set; }
    }
}
