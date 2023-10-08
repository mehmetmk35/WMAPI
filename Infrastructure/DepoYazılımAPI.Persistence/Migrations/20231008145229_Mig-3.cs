using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepoYazılımAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "CustomerItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "test2",
                table: "CustomerItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "test3",
                table: "CustomerItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "CustomerItems");

            migrationBuilder.DropColumn(
                name: "test2",
                table: "CustomerItems");

            migrationBuilder.DropColumn(
                name: "test3",
                table: "CustomerItems");
        }
    }
}
