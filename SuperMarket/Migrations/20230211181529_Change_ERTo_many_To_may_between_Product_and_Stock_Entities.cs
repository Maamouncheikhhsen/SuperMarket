using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class ChangeERTomanyTomaybetweenProductandStockEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEntityStockEntity");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "StockID",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "StockProducts",
                columns: table => new
                {
                    StockProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProducts", x => x.StockProductID);
                    table.ForeignKey(
                        name: "FK_StockProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockProducts_Stocks_StockID",
                        column: x => x.StockID,
                        principalTable: "Stocks",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_ProductID",
                table: "StockProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_StockID",
                table: "StockProducts",
                column: "StockID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "Stocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StockID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProductEntityStockEntity",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntityStockEntity", x => new { x.ProductID, x.StockID });
                    table.ForeignKey(
                        name: "FK_ProductEntityStockEntity_Products_StockID",
                        column: x => x.StockID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductEntityStockEntity_Stocks_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Stocks",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntityStockEntity_StockID",
                table: "ProductEntityStockEntity",
                column: "StockID");
        }
    }
}
