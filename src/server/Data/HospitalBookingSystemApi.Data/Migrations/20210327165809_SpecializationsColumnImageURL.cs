namespace HospitalBookingSystemApi.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SpecializationsColumnImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Specializations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Specializations");
        }
    }
}
