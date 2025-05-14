using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_users_table_drop_roles_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "UsersController");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "UsersController");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "UsersController");

            migrationBuilder.DropIndex(
                name: "IX_Events_UserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersController");

            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "UsersController");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "UsersController");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UsersController",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "Images",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Auth0UserId",
                table: "UsersController",
                type: "character varying(64)",
                maxLength: 64,
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "UsersController",
                column: "Auth0UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserAuth0UserId",
                table: "Events",
                column: "UserAuth0UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserAuth0UserId",
                table: "Bookings",
                column: "UserAuth0UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserAuth0UserId",
                table: "Bookings",
                column: "UserAuth0UserId",
                principalTable: "UsersController",
                principalColumn: "Auth0UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserAuth0UserId",
                table: "Events",
                column: "UserAuth0UserId",
                principalTable: "UsersController",
                principalColumn: "Auth0UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserAuth0UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserAuth0UserId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "UsersController");

            migrationBuilder.DropIndex(
                name: "IX_Events_UserAuth0UserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserAuth0UserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Auth0UserId",
                table: "UsersController");

            migrationBuilder.DropColumn(
                name: "UserAuth0UserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "UserAuth0UserId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UsersController",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Images",
                newName: "UploadedAt");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsersController",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "UsersController",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "UsersController",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "UsersController",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "UsersController",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "UsersController",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events",
                column: "UserId",
                principalTable: "UsersController",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "UsersController",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
