using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska_PSobczak.Migrations
{
    public partial class ini9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_UserId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "ClientData",
                table: "Visits",
                newName: "VisitsDescription");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_UserId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "VisitsDescription",
                table: "Visits",
                newName: "ClientData");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Visits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
