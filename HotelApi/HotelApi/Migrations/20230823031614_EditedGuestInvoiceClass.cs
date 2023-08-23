using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApi.Migrations
{
    /// <inheritdoc />
    public partial class EditedGuestInvoiceClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ReservationId",
                table: "Invoices",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Reservations_ReservationId",
                table: "Invoices",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Reservations_ReservationId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ReservationId",
                table: "Invoices");
        }
    }
}
