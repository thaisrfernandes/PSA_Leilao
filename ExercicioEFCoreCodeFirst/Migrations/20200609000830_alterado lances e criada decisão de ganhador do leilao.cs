using Microsoft.EntityFrameworkCore.Migrations;

namespace TF_PSA.Migrations
{
    public partial class alteradolancesecriadadecisãodeganhadordoleilao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Lances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lances_UsuarioId",
                table: "Lances",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lances_Usuarios_UsuarioId",
                table: "Lances",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lances_Usuarios_UsuarioId",
                table: "Lances");

            migrationBuilder.DropIndex(
                name: "IX_Lances_UsuarioId",
                table: "Lances");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Lances");
        }
    }
}
