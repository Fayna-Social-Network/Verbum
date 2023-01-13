using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeChatMessageRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("9de318b7-de37-452f-80ac-ff107687a0a3"));

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("15037253-fe7b-4760-9985-014a9e4fc753"), "General" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("15037253-fe7b-4760-9985-014a9e4fc753"));

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("9de318b7-de37-452f-80ac-ff107687a0a3"), "General" });
        }
    }
}
