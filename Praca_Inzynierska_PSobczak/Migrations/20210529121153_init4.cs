using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska_PSobczak.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctors_DoctorDataDoctorId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DoctorDataDoctorId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DoctorDataDoctorId",
                table: "Visits");

            migrationBuilder.AddColumn<string>(
                name: "DoctorData",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorData",
                table: "Visits");

            migrationBuilder.AddColumn<int>(
                name: "DoctorDataDoctorId",
                table: "Visits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorDataDoctorId",
                table: "Visits",
                column: "DoctorDataDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Doctors_DoctorDataDoctorId",
                table: "Visits",
                column: "DoctorDataDoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
