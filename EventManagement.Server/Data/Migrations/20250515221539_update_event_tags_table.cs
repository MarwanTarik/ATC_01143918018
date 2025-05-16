using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_event_tags_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTags_EventTagsId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_EventTags_EventTagsId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_EventTagsId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventTagsId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventTagsId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "EventTagsId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_EventTags_EventId",
                table: "EventTags",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTags_TagId",
                table: "EventTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTags_Events_EventId",
                table: "EventTags",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTags_Tags_TagId",
                table: "EventTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTags_Events_EventId",
                table: "EventTags");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTags_Tags_TagId",
                table: "EventTags");

            migrationBuilder.DropIndex(
                name: "IX_EventTags_EventId",
                table: "EventTags");

            migrationBuilder.DropIndex(
                name: "IX_EventTags_TagId",
                table: "EventTags");

            migrationBuilder.AddColumn<int>(
                name: "EventTagsId",
                table: "Tags",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventTagsId",
                table: "Events",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventTagsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventTagsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "EventTagsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "EventTagsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "EventTagsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                column: "EventTagsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                column: "EventTagsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                column: "EventTagsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                column: "EventTagsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                column: "EventTagsId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EventTagsId",
                table: "Tags",
                column: "EventTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTagsId",
                table: "Events",
                column: "EventTagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTags_EventTagsId",
                table: "Events",
                column: "EventTagsId",
                principalTable: "EventTags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_EventTags_EventTagsId",
                table: "Tags",
                column: "EventTagsId",
                principalTable: "EventTags",
                principalColumn: "Id");
        }
    }
}
