using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipToGroupMessageComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groupMessageComments_groupMessageComments_GroupMessageComme~",
                table: "groupMessageComments");

            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("5cb468ef-185b-44a0-9162-46f2a69eb9af"));

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupMessageCommentId",
                table: "groupMessageComments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "groupMessageId",
                table: "groupMessageComments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("5db7e878-ca4d-4ce1-8400-09f7fc7d6b37"), "General" });

            migrationBuilder.AddForeignKey(
                name: "FK_groupMessageComments_groupMessageComments_GroupMessageComme~",
                table: "groupMessageComments",
                column: "GroupMessageCommentId",
                principalTable: "groupMessageComments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groupMessageComments_groupMessageComments_GroupMessageComme~",
                table: "groupMessageComments");

            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("5db7e878-ca4d-4ce1-8400-09f7fc7d6b37"));

            migrationBuilder.DropColumn(
                name: "groupMessageId",
                table: "groupMessageComments");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupMessageCommentId",
                table: "groupMessageComments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("5cb468ef-185b-44a0-9162-46f2a69eb9af"), "General" });

            migrationBuilder.AddForeignKey(
                name: "FK_groupMessageComments_groupMessageComments_GroupMessageComme~",
                table: "groupMessageComments",
                column: "GroupMessageCommentId",
                principalTable: "groupMessageComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
