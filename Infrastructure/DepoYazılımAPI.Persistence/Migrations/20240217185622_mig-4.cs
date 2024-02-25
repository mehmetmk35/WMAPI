using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepoYazılımAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRecords_Files_StockCardImageFileID",
                table: "ItemRecords");

            migrationBuilder.DropIndex(
                name: "IX_ItemRecords_StockCardImageFileID",
                table: "ItemRecords");

            migrationBuilder.DropColumn(
                name: "StockCardImageFileID",
                table: "ItemRecords");

            migrationBuilder.CreateTable(
                name: "StockCardImageFileStockCardRecord",
                columns: table => new
                {
                    StockCardImageFileID = table.Column<int>(type: "int", nullable: false),
                    StockCardRecordStockCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCardImageFileStockCardRecord", x => new { x.StockCardImageFileID, x.StockCardRecordStockCode });
                    table.ForeignKey(
                        name: "FK_StockCardImageFileStockCardRecord_Files_StockCardImageFileID",
                        column: x => x.StockCardImageFileID,
                        principalTable: "Files",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockCardImageFileStockCardRecord_ItemRecords_StockCardRecordStockCode",
                        column: x => x.StockCardRecordStockCode,
                        principalTable: "ItemRecords",
                        principalColumn: "StockCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockCardImageFileStockCardRecord_StockCardRecordStockCode",
                table: "StockCardImageFileStockCardRecord",
                column: "StockCardRecordStockCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockCardImageFileStockCardRecord");

            migrationBuilder.AddColumn<int>(
                name: "StockCardImageFileID",
                table: "ItemRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemRecords_StockCardImageFileID",
                table: "ItemRecords",
                column: "StockCardImageFileID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRecords_Files_StockCardImageFileID",
                table: "ItemRecords",
                column: "StockCardImageFileID",
                principalTable: "Files",
                principalColumn: "ID");
        }
    }
}
