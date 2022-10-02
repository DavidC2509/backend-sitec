using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Data.Command.Migrations
{
    public partial class TMP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fassil_Product",
                columns: table => new
                {
                    nProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    sName = table.Column<string>(type: "text", nullable: false),
                    sDescripcion = table.Column<string>(type: "text", nullable: true),
                    sBarCode = table.Column<string>(type: "text", nullable: false),
                    nPrice = table.Column<double>(type: "double", nullable: false),
                    nPriceIva = table.Column<double>(type: "double", nullable: false),
                    bStatus = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    dCompDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fassil_Product", x => x.nProductId);
                });

            migrationBuilder.CreateTable(
                name: "fassil_Warehouse",
                columns: table => new
                {
                    nWarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    sName = table.Column<string>(type: "text", nullable: false),
                    sPlace = table.Column<string>(type: "text", nullable: false),
                    bStatus = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    dCompDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fassil_Warehouse", x => x.nWarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "fassil_WarehouseProduct",
                columns: table => new
                {
                    nWarehouseProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nProductId = table.Column<int>(type: "int", nullable: false),
                    nWarehouseId = table.Column<int>(type: "int", nullable: false),
                    nCount = table.Column<int>(type: "int", nullable: false),
                    dCompDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fassil_WarehouseProduct", x => x.nWarehouseProductId);
                    table.ForeignKey(
                        name: "FK_fassil_WarehouseProduct_fassil_Product_nProductId",
                        column: x => x.nProductId,
                        principalTable: "fassil_Product",
                        principalColumn: "nProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fassil_WarehouseProduct_fassil_Warehouse_nWarehouseId",
                        column: x => x.nWarehouseId,
                        principalTable: "fassil_Warehouse",
                        principalColumn: "nWarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fassil_WarehouseProductSale",
                columns: table => new
                {
                    nWarehouseProductSale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nWarehouseProductId = table.Column<int>(type: "int", nullable: false),
                    dDateSell = table.Column<DateTime>(type: "datetime", nullable: false),
                    nCountSell = table.Column<int>(type: "int", nullable: false),
                    nPriceSell = table.Column<double>(type: "double", nullable: false),
                    dCompDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fassil_WarehouseProductSale", x => x.nWarehouseProductSale);
                    table.ForeignKey(
                        name: "FK_fassil_WarehouseProductSale_fassil_WarehouseProduct_nWarehou~",
                        column: x => x.nWarehouseProductId,
                        principalTable: "fassil_WarehouseProduct",
                        principalColumn: "nWarehouseProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fassil_WarehouseProduct_nProductId",
                table: "fassil_WarehouseProduct",
                column: "nProductId");

            migrationBuilder.CreateIndex(
                name: "IX_fassil_WarehouseProduct_nWarehouseId",
                table: "fassil_WarehouseProduct",
                column: "nWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_fassil_WarehouseProductSale_nWarehouseProductId",
                table: "fassil_WarehouseProductSale",
                column: "nWarehouseProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fassil_WarehouseProductSale");

            migrationBuilder.DropTable(
                name: "fassil_WarehouseProduct");

            migrationBuilder.DropTable(
                name: "fassil_Product");

            migrationBuilder.DropTable(
                name: "fassil_Warehouse");
        }
    }
}
