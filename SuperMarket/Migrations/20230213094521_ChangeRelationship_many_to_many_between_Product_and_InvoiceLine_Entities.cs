using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipmanytomanybetweenProductandInvoiceLineEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Products_ProductID",
                table: "InvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLines_ProductID",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "InvoiceLines");

            migrationBuilder.CreateTable(
                name: "ProductInvoiceLineEntity",
                columns: table => new
                {
                    ProductInvoiceLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInvoiceLineEntity", x => x.ProductInvoiceLineID);
                    table.ForeignKey(
                        name: "FK_ProductInvoiceLineEntity_InvoiceLines_InvoiceLineID",
                        column: x => x.InvoiceLineID,
                        principalTable: "InvoiceLines",
                        principalColumn: "InvoiceLineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInvoiceLineEntity_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoiceLineEntity_InvoiceLineID",
                table: "ProductInvoiceLineEntity",
                column: "InvoiceLineID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoiceLineEntity_ProductID",
                table: "ProductInvoiceLineEntity",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInvoiceLineEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "InvoiceLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ProductID",
                table: "InvoiceLines",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_Products_ProductID",
                table: "InvoiceLines",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
