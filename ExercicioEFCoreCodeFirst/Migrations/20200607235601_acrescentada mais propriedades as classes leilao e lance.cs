using Microsoft.EntityFrameworkCore.Migrations;

namespace TF_PSA.Migrations
{
    public partial class acrescentadamaispropriedadesasclassesleilaoelance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanceAberto",
                table: "Leiloes");

            migrationBuilder.RenameColumn(
                name: "dataInicio",
                table: "Leiloes",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "dataFinal",
                table: "Leiloes",
                newName: "DataFinal");

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Leiloes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaDeLance",
                table: "Leiloes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Leiloes",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Leiloes");

            migrationBuilder.DropColumn(
                name: "CategoriaDeLance",
                table: "Leiloes");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Leiloes");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Leiloes",
                newName: "dataInicio");

            migrationBuilder.RenameColumn(
                name: "DataFinal",
                table: "Leiloes",
                newName: "dataFinal");

            migrationBuilder.AddColumn<bool>(
                name: "LanceAberto",
                table: "Leiloes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
