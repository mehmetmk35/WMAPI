using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepoYazılımAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerItems",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MK1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MK2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemRecords",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure1Denominator = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitOfMeasure1Numerator = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitOfMeasure2Denominator = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitOfMeasure2Numerator = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingPrice1 = table.Column<long>(type: "bigint", nullable: false),
                    SellingPrice2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VATRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseVATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePrice2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MK1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MK2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRecords", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Barcodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockCodeID = table.Column<int>(type: "int", nullable: true),
                    Barcodes = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Barcodes_ItemRecords_StockCodeID",
                        column: x => x.StockCodeID,
                        principalTable: "ItemRecords",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barcodes_StockCodeID",
                table: "Barcodes",
                column: "StockCodeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barcodes");

            migrationBuilder.DropTable(
                name: "CustomerItems");

            migrationBuilder.DropTable(
                name: "ItemRecords");
        }
    }
}
