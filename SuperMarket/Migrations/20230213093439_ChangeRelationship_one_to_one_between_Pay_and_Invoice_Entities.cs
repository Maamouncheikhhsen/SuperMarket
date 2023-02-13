using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshiponetoonebetweenPayandInvoiceEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoices_PayID",
                table: "Invoices");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PayID",
                table: "Invoices",
                column: "PayID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoices_PayID",
                table: "Invoices");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PayID",
                table: "Invoices",
                column: "PayID");
        }
    }
}
