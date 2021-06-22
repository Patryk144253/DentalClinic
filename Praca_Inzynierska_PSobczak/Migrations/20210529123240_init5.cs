using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska_PSobczak.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorData",
                table: "Visits");

            migrationBuilder.AddColumn<int>(
                name: "DoktorID",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoktorID",
                table: "Visits",
                column: "DoktorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Doctors_DoktorID",
                table: "Visits",
                column: "DoktorID",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctors_DoktorID",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DoktorID",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DoktorID",
                table: "Visits");

            migrationBuilder.AddColumn<string>(
                name: "DoctorData",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
