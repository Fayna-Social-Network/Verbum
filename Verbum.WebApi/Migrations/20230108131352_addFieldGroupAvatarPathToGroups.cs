using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addFieldGroupAvatarPathToGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("e4f2c449-9e88-4317-98db-df2312798dda"));

            migrationBuilder.AddColumn<string>(
                name: "GroupAvatarPath",
                table: "groups",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("98c83c19-4222-40fd-ae13-3480c1c2d7bd"), "General" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("98c83c19-4222-40fd-ae13-3480c1c2d7bd"));

            migrationBuilder.DropColumn(
                name: "GroupAvatarPath",
                table: "groups");

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("e4f2c449-9e88-4317-98db-df2312798dda"), "General" });
        }
    }
}
