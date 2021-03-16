namespace HospitalBookingSystemApi.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SlotColumnOrderIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Slots_Order",
                table: "Slots",
                column: "Order",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Slots_Order",
                table: "Slots");
        }
    }
}
