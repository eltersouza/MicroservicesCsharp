﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.CourseService.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryFieldtoStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Students");
        }
    }
}
