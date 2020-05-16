using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TF_PSA.Migrations
{
    public partial class alterandonomedobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leiloes",
                columns: table => new
                {
                    LeilaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanceAberto = table.Column<bool>(nullable: false),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataFinal = table.Column<DateTime>(nullable: false),
                    IdUsuarioResponsavel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiloes", x => x.LeilaoId);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoBreve = table.Column<string>(nullable: true),
                    DescricaoCompleta = table.Column<string>(nullable: true),
                    Categoria = table.Column<int>(nullable: false),
                    LeilaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Itens_Leiloes_LeilaoId",
                        column: x => x.LeilaoId,
                        principalTable: "Leiloes",
                        principalColumn: "LeilaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lances",
                columns: table => new
                {
                    LanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    EmailUsuario = table.Column<string>(nullable: true),
                    LeilaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lances", x => x.LanceId);
                    table.ForeignKey(
                        name: "FK_Lances_Leiloes_LeilaoId",
                        column: x => x.LeilaoId,
                        principalTable: "Leiloes",
                        principalColumn: "LeilaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itens_LeilaoId",
                table: "Itens",
                column: "LeilaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lances_LeilaoId",
                table: "Lances",
                column: "LeilaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Lances");

            migrationBuilder.DropTable(
                name: "Leiloes");
        }
    }
}
