using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalBookingSystemApi.Data.Migrations
{
    public partial class PatientColumnSsnIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Patients_SSN",
                table: "Patients",
                column: "SSN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_SSN",
                table: "Patients");
        }
    }
}
