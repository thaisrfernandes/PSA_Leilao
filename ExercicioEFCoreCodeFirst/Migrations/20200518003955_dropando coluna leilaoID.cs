using Microsoft.EntityFrameworkCore.Migrations;

namespace TF_PSA.Migrations
{
    public partial class dropandocolunaleilaoID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lances_Leiloes_LeilaoId",
                table: "Lances");

            migrationBuilder.AlterColumn<int>(
                name: "LeilaoId",
                table: "Lances",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lances_Leiloes_LeilaoId",
                table: "Lances",
                column: "LeilaoId",
                principalTable: "Leiloes",
                principalColumn: "LeilaoId",
                onDelete: ReferentialAction.Restrict);
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
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lances_Leiloes_LeilaoId",
                table: "Lances",
                column: "LeilaoId",
                principalTable: "Leiloes",
                principalColumn: "LeilaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
