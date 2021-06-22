using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska_PSobczak.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctors_DoctorID",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Visits",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_DoctorID",
                table: "Visits",
                newName: "IX_Visits_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Doctors_DoctorId",
                table: "Visits",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctors_DoctorId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Visits",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_DoctorId",
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
    }
}
