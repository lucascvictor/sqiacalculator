using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SQIACalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Indexador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cotacao",
                columns: new[] { "Id", "Data", "Indexador", "Valor" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 10.5 },
                    { 2, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 10.5 },
                    { 3, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 10.5 },
                    { 6, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.25 },
                    { 7, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.25 },
                    { 8, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.25 },
                    { 9, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.25 },
                    { 10, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.25 },
                    { 13, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.25 },
                    { 14, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.25 },
                    { 15, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.25 },
                    { 16, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 9.0 },
                    { 17, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 9.0 },
                    { 20, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 9.0 },
                    { 21, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 7.75 },
                    { 22, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 7.75 },
                    { 23, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 7.75 },
                    { 24, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 7.75 },
                    { 27, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 8.25 },
                    { 28, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 8.25 },
                    { 29, new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 8.25 },
                    { 30, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 8.25 },
                    { 31, new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 8.25 },
                    { 32, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.0 },
                    { 33, new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.5 },
                    { 34, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 11.0 },
                    { 35, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.2 },
                    { 36, new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 13.0 },
                    { 37, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.4 },
                    { 38, new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQI", 12.7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotacao");
        }
    }
}
