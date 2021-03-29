using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalBookingSystemApi.Data.Migrations
{
    public partial class tableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Doctors_DoctorId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Patients_PatientId",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_Like_PatientId",
                table: "Likes",
                newName: "IX_Likes_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "DoctorId", "PatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Doctors_DoctorId",
                table: "Likes",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Patients_PatientId",
                table: "Likes",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Doctors_DoctorId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Patients_PatientId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PatientId",
                table: "Like",
                newName: "IX_Like_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                columns: new[] { "DoctorId", "PatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Doctors_DoctorId",
                table: "Like",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Patients_PatientId",
                table: "Like",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
