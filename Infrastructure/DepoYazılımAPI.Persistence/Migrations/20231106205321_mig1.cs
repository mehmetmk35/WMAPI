using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepoYazılımAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchCode = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure1Denominator = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    UnitOfMeasure1Numerator = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    UnitOfMeasure2Denominator = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    UnitOfMeasure2Numerator = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    SellingPrice1 = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    SellingPrice2 = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    VATRate = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    PurchaseVATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice1 = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    PurchasePrice2 = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Lock = table.Column<bool>(type: "bit", nullable: true),
                    AdditionalFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MK1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MK2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchCode = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
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
                    StockCodeID = table.Column<int>(type: "int", nullable: false),
                    Barcodes = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Barcodes_ItemRecords_StockCodeID",
                        column: x => x.StockCodeID,
                        principalTable: "ItemRecords",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
