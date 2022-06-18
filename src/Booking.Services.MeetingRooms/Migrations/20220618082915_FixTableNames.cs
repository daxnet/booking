using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Services.MeetingRooms.Migrations
{
    public partial class FixTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_MeetingRooms_MeetingRoomId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomConfiguration_MeetingRooms_MeetingRoomId",
                table: "RoomConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomConfiguration",
                table: "RoomConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "RoomConfiguration",
                newName: "RoomConfigurations");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_RoomConfiguration_MeetingRoomId",
                table: "RoomConfigurations",
                newName: "IX_RoomConfigurations_MeetingRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_MeetingRoomId",
                table: "Locations",
                newName: "IX_Locations_MeetingRoomId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLocked",
                table: "MeetingRooms",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MeetingRooms",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4096)",
                oldMaxLength: 4096);

            migrationBuilder.AlterColumn<bool>(
                name: "HasWhiteBoard",
                table: "RoomConfigurations",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "HasProjector",
                table: "RoomConfigurations",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomConfigurations",
                table: "RoomConfigurations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_MeetingRooms_MeetingRoomId",
                table: "Locations",
                column: "MeetingRoomId",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomConfigurations_MeetingRooms_MeetingRoomId",
                table: "RoomConfigurations",
                column: "MeetingRoomId",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MeetingRooms_MeetingRoomId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomConfigurations_MeetingRooms_MeetingRoomId",
                table: "RoomConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomConfigurations",
                table: "RoomConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "RoomConfigurations",
                newName: "RoomConfiguration");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_RoomConfigurations_MeetingRoomId",
                table: "RoomConfiguration",
                newName: "IX_RoomConfiguration_MeetingRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_MeetingRoomId",
                table: "Location",
                newName: "IX_Location_MeetingRoomId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLocked",
                table: "MeetingRooms",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MeetingRooms",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(4096)",
                oldMaxLength: 4096,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HasWhiteBoard",
                table: "RoomConfiguration",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HasProjector",
                table: "RoomConfiguration",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomConfiguration",
                table: "RoomConfiguration",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_MeetingRooms_MeetingRoomId",
                table: "Location",
                column: "MeetingRoomId",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomConfiguration_MeetingRooms_MeetingRoomId",
                table: "RoomConfiguration",
                column: "MeetingRoomId",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
