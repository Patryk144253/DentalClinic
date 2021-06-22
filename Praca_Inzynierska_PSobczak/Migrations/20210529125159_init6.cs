using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska_PSobczak.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctors_DoktorID",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "DoktorID",
                table: "Visits",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_DoktorID",
                table: "Visits",
                newName: "IX_Visits_DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Doctors_DoctorID",
                table: "Visits",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctors_DoctorID",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Visits",
                newName: "DoktorID");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_DoctorID",
                table: "Visits",
                newName: "IX_Visits_DoktorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Doctors_DoktorID",
                table: "Visits",
                column: "DoktorID",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
