using Microsoft.EntityFrameworkCore.Migrations;

namespace TF_PSA.Migrations
{
    public partial class subindocolunaleilaoID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lances_Leiloes_LeilaoId",
                table: "Lances");

            migrationBuilder.AlterColumn<int>(
                name: "LeilaoId",
                table: "Lances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lances_Leiloes_LeilaoId",
                table: "Lances",
                column: "LeilaoId",
                principalTable: "Leiloes",
                principalColumn: "LeilaoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lances_Leiloes_LeilaoId",
                table: "Lances");

            migrationBuilder.AlterColumn<int>(
                name: "LeilaoId",
                table: "Lances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Lances_Leiloes_LeilaoId",
                table: "Lances",
                column: "LeilaoId",
                principalTable: "Leiloes",
                principalColumn: "LeilaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
