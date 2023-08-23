using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApi.Migrations
{
    /// <inheritdoc />
    public partial class EditedReservationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "Reservations",
                newName: "TotalPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Reservations",
                newName: "totalPrice");
        }
    }
}
