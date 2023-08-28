using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "lookup");

            migrationBuilder.CreateTable(
                name: "CalculatedTax",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnualIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCalculated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatedTax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TaxType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRates",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    FromAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "PostalCodes",
                columns: new[] { "Id", "Code", "TaxType" },
                values: new object[,]
                {
                    { 1, "7441", "Progressive" },
                    { 2, "A100", "Flat Value" },
                    { 3, "7000", "Flat Rate" },
                    { 4, "1000", "Progressive" }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "TaxRates",
                columns: new[] { "Id", "FromAmount", "Rate", "ToAmount" },
                values: new object[,]
                {
                    { 1, 0m, 10, 8350m },
                    { 2, 8351m, 15, 33950m },
                    { 3, 33951m, 25, 82250m },
                    { 4, 82251m, 28, 171550m },
                    { 5, 171551m, 33, 372950m },
                    { 6, 372951m, 35, 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatedTax",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PostalCodes",
                schema: "lookup");

            migrationBuilder.DropTable(
                name: "TaxRates",
                schema: "lookup");
        }
    }
}
