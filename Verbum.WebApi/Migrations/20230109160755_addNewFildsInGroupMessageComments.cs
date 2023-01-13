using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addNewFildsInGroupMessageComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("98c83c19-4222-40fd-ae13-3480c1c2d7bd"));

            migrationBuilder.AddColumn<Guid>(
                name: "GroupMessageCommentId",
                table: "groupMessageComments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("ed0a9c1b-349f-47c8-8eff-17b5c41e3c68"), "General" });

            migrationBuilder.CreateIndex(
                name: "IX_groupMessageComments_GroupMessageCommentId",
                table: "groupMessageComments",
                column: "GroupMessageCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_groupMessageComments_groupMessageComments_GroupMessageComme~",
                table: "groupMessageComments",
                column: "GroupMessageCommentId",
                principalTable: "groupMessageComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groupMessageComments_groupMessageComments_GroupMessageComme~",
                table: "groupMessageComments");

            migrationBuilder.DropIndex(
                name: "IX_groupMessageComments_GroupMessageCommentId",
                table: "groupMessageComments");

            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("ed0a9c1b-349f-47c8-8eff-17b5c41e3c68"));

            migrationBuilder.DropColumn(
                name: "GroupMessageCommentId",
                table: "groupMessageComments");

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("98c83c19-4222-40fd-ae13-3480c1c2d7bd"), "General" });
        }
    }
}
