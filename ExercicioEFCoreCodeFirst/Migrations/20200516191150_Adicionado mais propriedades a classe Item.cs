using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TF_PSA.Migrations
{
    public partial class AdicionadomaispropriedadesaclasseItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Itens",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Itens");
        }
    }
}
