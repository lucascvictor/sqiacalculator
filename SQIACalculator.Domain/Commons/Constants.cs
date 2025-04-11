namespace SQIACalculator.Domain.Commons
{
    public static class Indexadores
    {
        public const string SQI = "SQI";
    }

    public static class Calculos
    {
        public static decimal FatorDiario(double cotacao) => Math.Round((decimal)Math.Pow(1 + (cotacao / 100), 1.0 / 252), 16);
    }
}
