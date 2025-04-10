﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQIACalculator.Infrastructure.Context;

#nullable disable

namespace SQIACalculator.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SQIACalculator.Domain.Entities.Cotacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Indexador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Cotacao", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Data = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 10.5
                        },
                        new
                        {
                            Id = 2,
                            Data = new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 10.5
                        },
                        new
                        {
                            Id = 3,
                            Data = new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 10.5
                        },
                        new
                        {
                            Id = 6,
                            Data = new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.25
                        },
                        new
                        {
                            Id = 7,
                            Data = new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.25
                        },
                        new
                        {
                            Id = 8,
                            Data = new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.25
                        },
                        new
                        {
                            Id = 9,
                            Data = new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.25
                        },
                        new
                        {
                            Id = 10,
                            Data = new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.25
                        },
                        new
                        {
                            Id = 13,
                            Data = new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.25
                        },
                        new
                        {
                            Id = 14,
                            Data = new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.25
                        },
                        new
                        {
                            Id = 15,
                            Data = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.25
                        },
                        new
                        {
                            Id = 16,
                            Data = new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 9.0
                        },
                        new
                        {
                            Id = 17,
                            Data = new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 9.0
                        },
                        new
                        {
                            Id = 20,
                            Data = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 9.0
                        },
                        new
                        {
                            Id = 21,
                            Data = new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 7.75
                        },
                        new
                        {
                            Id = 22,
                            Data = new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 7.75
                        },
                        new
                        {
                            Id = 23,
                            Data = new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 7.75
                        },
                        new
                        {
                            Id = 24,
                            Data = new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 7.75
                        },
                        new
                        {
                            Id = 27,
                            Data = new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 8.25
                        },
                        new
                        {
                            Id = 28,
                            Data = new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 8.25
                        },
                        new
                        {
                            Id = 29,
                            Data = new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 8.25
                        },
                        new
                        {
                            Id = 30,
                            Data = new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 8.25
                        },
                        new
                        {
                            Id = 31,
                            Data = new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 8.25
                        },
                        new
                        {
                            Id = 32,
                            Data = new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.0
                        },
                        new
                        {
                            Id = 33,
                            Data = new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.5
                        },
                        new
                        {
                            Id = 34,
                            Data = new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 11.0
                        },
                        new
                        {
                            Id = 35,
                            Data = new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.199999999999999
                        },
                        new
                        {
                            Id = 36,
                            Data = new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 13.0
                        },
                        new
                        {
                            Id = 37,
                            Data = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.4
                        },
                        new
                        {
                            Id = 38,
                            Data = new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indexador = "SQI",
                            Valor = 12.699999999999999
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
