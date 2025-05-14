using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_users_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_EventStatus_BookingStatusId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserAuth0UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Images_ImageId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserAuth0UserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ImageId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_UserAuth0UserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserAuth0UserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UsersController");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UsersController");

            migrationBuilder.DropColumn(
                name: "UserAuth0UserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "UserAuth0UserId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "EventsId",
                table: "Images",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersAuth0UserId",
                table: "Images",
                type: "character varying(64)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersAuth0UserId",
                table: "Events",
                type: "character varying(64)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersAuth0UserId",
                table: "Bookings",
                type: "character varying(64)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventsId",
                table: "Images",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UsersAuth0UserId",
                table: "Images",
                column: "UsersAuth0UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UsersAuth0UserId",
                table: "Events",
                column: "UsersAuth0UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UsersAuth0UserId",
                table: "Bookings",
                column: "UsersAuth0UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingStatus_BookingStatusId",
                table: "Bookings",
                column: "BookingStatusId",
                principalTable: "BookingStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UsersAuth0UserId",
                table: "Bookings",
                column: "UsersAuth0UserId",
                principalTable: "UsersController",
                principalColumn: "Auth0UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UsersAuth0UserId",
                table: "Events",
                column: "UsersAuth0UserId",
                principalTable: "UsersController",
                principalColumn: "Auth0UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Events_EventsId",
                table: "Images",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_UsersAuth0UserId",
                table: "Images",
                column: "UsersAuth0UserId",
                principalTable: "UsersController",
                principalColumn: "Auth0UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingStatus_BookingStatusId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UsersAuth0UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UsersAuth0UserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_EventsId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Users_UsersAuth0UserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_EventsId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UsersAuth0UserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Events_UsersAuth0UserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UsersAuth0UserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UsersAuth0UserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UsersAuth0UserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "UsersAuth0UserId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UsersController",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UsersController",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAuth0UserId",
                table: "Events",
                type: "character varying(64)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAuth0UserId",
                table: "Bookings",
                type: "character varying(64)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ImageId",
                table: "Events",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserAuth0UserId",
                table: "Events",
                column: "UserAuth0UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserAuth0UserId",
                table: "Bookings",
                column: "UserAuth0UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_EventStatus_BookingStatusId",
                table: "Bookings",
                column: "BookingStatusId",
                principalTable: "EventStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserAuth0UserId",
                table: "Bookings",
                column: "UserAuth0UserId",
                principalTable: "UsersController",
                principalColumn: "Auth0UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Images_ImageId",
                table: "Events",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserAuth0UserId",
                table: "Events",
                column: "UserAuth0UserId",
                principalTable: "UsersController",
                principalColumn: "Auth0UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
