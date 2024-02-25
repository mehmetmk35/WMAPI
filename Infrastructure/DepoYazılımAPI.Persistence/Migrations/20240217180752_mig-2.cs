using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepoYazılımAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCard",
                table: "Files");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StockCard",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
