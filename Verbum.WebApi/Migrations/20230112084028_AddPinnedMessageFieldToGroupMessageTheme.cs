using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPinnedMessageFieldToGroupMessageTheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("5db7e878-ca4d-4ce1-8400-09f7fc7d6b37"));

            migrationBuilder.AddColumn<Guid>(
                name: "PinnedMessage",
                table: "groupsThemes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("9de318b7-de37-452f-80ac-ff107687a0a3"), "General" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("9de318b7-de37-452f-80ac-ff107687a0a3"));

            migrationBuilder.DropColumn(
                name: "PinnedMessage",
                table: "groupsThemes");

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("5db7e878-ca4d-4ce1-8400-09f7fc7d6b37"), "General" });
        }
    }
}
