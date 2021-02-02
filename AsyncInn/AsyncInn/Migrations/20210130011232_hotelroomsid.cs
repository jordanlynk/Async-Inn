using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class hotelroomsid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomID", "AmenityID", "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { 1, 1, null, true, 100m, 23 });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomID", "AmenityID", "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { 2, 2, null, true, 169m, 69 });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomID", "AmenityID", "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { 3, 3, null, false, 170m, 88 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomID" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
