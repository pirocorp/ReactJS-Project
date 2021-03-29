﻿namespace HospitalBookingSystemApi.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class LikesColumnRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Likes");
        }
    }
}
