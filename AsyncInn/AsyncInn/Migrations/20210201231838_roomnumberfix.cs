using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class roomnumberfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomID" });
        }
    }
}
