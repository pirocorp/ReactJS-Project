﻿namespace HospitalBookingSystemApi.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class TableSlotColumnOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Slots",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Slots");
        }
    }
}
