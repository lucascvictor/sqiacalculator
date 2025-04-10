using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQIACalculator.Domain.Entities;

namespace SQIACalculator.Infrastructure.Seeds
{
    public class CotacaoSeed : IEntityTypeConfiguration<Cotacao>
    {
        public void Configure(EntityTypeBuilder<Cotacao> builder)
        {
            builder.HasData(
                new Cotacao { Id = 1, Data = new DateTime(2025, 1, 1), Indexador = "SQI", Valor = 10.50 },
                new Cotacao { Id = 2, Data = new DateTime(2025, 1, 2), Indexador = "SQI", Valor = 10.50 },
                new Cotacao { Id = 3, Data = new DateTime(2025, 1, 3), Indexador = "SQI", Valor = 10.50 },
                new Cotacao { Id = 6, Data = new DateTime(2025, 1, 6), Indexador = "SQI", Valor = 12.25 },
                new Cotacao { Id = 7, Data = new DateTime(2025, 1, 7), Indexador = "SQI", Valor = 12.25 },
                new Cotacao { Id = 8, Data = new DateTime(2025, 1, 8), Indexador = "SQI", Valor = 12.25 },
                new Cotacao { Id = 9, Data = new DateTime(2025, 1, 9), Indexador = "SQI", Valor = 12.25 },
                new Cotacao { Id = 10, Data = new DateTime(2025, 1, 10), Indexador = "SQI", Valor = 12.25 },
                new Cotacao { Id = 13, Data = new DateTime(2025, 1, 13), Indexador = "SQI", Valor = 12.25 },
                new Cotacao { Id = 14, Data = new DateTime(2025, 1, 14), Indexador = "SQI", Valor = 12.25 },
                new Cotacao { Id = 15, Data = new DateTime(2025, 1, 15), Indexador = "SQI", Valor = 12.25 },
                new Cotacao { Id = 16, Data = new DateTime(2025, 1, 16), Indexador = "SQI", Valor = 9.00 },
                new Cotacao { Id = 17, Data = new DateTime(2025, 1, 17), Indexador = "SQI", Valor = 9.00 },
                new Cotacao { Id = 20, Data = new DateTime(2025, 1, 20), Indexador = "SQI", Valor = 9.00 },
                new Cotacao { Id = 21, Data = new DateTime(2025, 1, 21), Indexador = "SQI", Valor = 7.75 },
                new Cotacao { Id = 22, Data = new DateTime(2025, 1, 22), Indexador = "SQI", Valor = 7.75 },
                new Cotacao { Id = 23, Data = new DateTime(2025, 1, 23), Indexador = "SQI", Valor = 7.75 },
                new Cotacao { Id = 24, Data = new DateTime(2025, 1, 24), Indexador = "SQI", Valor = 7.75 },
                new Cotacao { Id = 27, Data = new DateTime(2025, 1, 27), Indexador = "SQI", Valor = 8.25 },
                new Cotacao { Id = 28, Data = new DateTime(2025, 1, 28), Indexador = "SQI", Valor = 8.25 },
                new Cotacao { Id = 29, Data = new DateTime(2025, 1, 29), Indexador = "SQI", Valor = 8.25 },
                new Cotacao { Id = 30, Data = new DateTime(2025, 1, 30), Indexador = "SQI", Valor = 8.25 },
                new Cotacao { Id = 31, Data = new DateTime(2025, 1, 31), Indexador = "SQI", Valor = 8.25 },
                new Cotacao { Id = 32, Data = new DateTime(2025, 3, 13), Indexador = "SQI", Valor = 12 },
                new Cotacao { Id = 33, Data = new DateTime(2025, 3, 14), Indexador = "SQI", Valor = 12.5 },
                new Cotacao { Id = 34, Data = new DateTime(2025, 3, 17), Indexador = "SQI", Valor = 11 },
                new Cotacao { Id = 35, Data = new DateTime(2025, 3, 18), Indexador = "SQI", Valor = 12.2 },
                new Cotacao { Id = 36, Data = new DateTime(2025, 3, 19), Indexador = "SQI", Valor = 13 },
                new Cotacao { Id = 37, Data = new DateTime(2025, 3, 20), Indexador = "SQI", Valor = 12.4 },
                new Cotacao { Id = 38, Data = new DateTime(2025, 3, 21), Indexador = "SQI", Valor = 12.7} 
            );
        }
    }
}
