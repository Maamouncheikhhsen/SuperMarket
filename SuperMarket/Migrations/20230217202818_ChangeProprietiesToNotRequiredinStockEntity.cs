using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProprietiesToNotRequiredinStockEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Products_ProductID",
                table: "StockProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Stocks_StockID",
                table: "StockProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "StockID",
                table: "StockProducts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "StockProducts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Products_ProductID",
                table: "StockProducts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Stocks_StockID",
                table: "StockProducts",
                column: "StockID",
                principalTable: "Stocks",
                principalColumn: "StockID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Products_ProductID",
                table: "StockProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Stocks_StockID",
                table: "StockProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "StockID",
                table: "StockProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "StockProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Products_ProductID",
                table: "StockProducts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Stocks_StockID",
                table: "StockProducts",
                column: "StockID",
                principalTable: "Stocks",
                principalColumn: "StockID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
