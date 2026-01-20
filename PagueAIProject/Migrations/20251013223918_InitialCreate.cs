using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoDeliverIT.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContaRegraAtrasos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiasMinimo = table.Column<int>(type: "int", nullable: false),
                    DiasMaximo = table.Column<int>(type: "int", nullable: true),
                    Multa = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    JurosDia = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaRegraAtrasos", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorOriginal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DataVencimento = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    DataPagamento = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    ValorCorrigido = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiasAtraso = table.Column<int>(type: "int", nullable: false),
                    Multa = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    JurosDia = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ContaRegraAtrasos",
                columns: new[] { "ID", "DiasMaximo", "DiasMinimo", "JurosDia", "Multa" },
                values: new object[,]
                {
                    { 1, 3, 0, 0.1m, 0.02m },
                    { 2, 5, 4, 0.2m, 0.03m },
                    { 3, null, 6, 0.3m, 0.05m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaRegraAtrasos");

            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
