﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RidePoint.Migrations
{
    /// <inheritdoc />
    public partial class addjwtcolumbinuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JwtSecret",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JwtSecret",
                table: "Users");
        }
    }
}
