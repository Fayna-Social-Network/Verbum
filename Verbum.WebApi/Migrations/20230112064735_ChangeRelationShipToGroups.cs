using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationShipToGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groups_Users_UserId",
                table: "groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_groups_Groupid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Groupid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_groups_UserId",
                table: "groups");

            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("ed0a9c1b-349f-47c8-8eff-17b5c41e3c68"));

            migrationBuilder.DropColumn(
                name: "Groupid",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "GroupVerbumUser",
                columns: table => new
                {
                    groupsid = table.Column<Guid>(type: "uuid", nullable: false),
                    usersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupVerbumUser", x => new { x.groupsid, x.usersId });
                    table.ForeignKey(
                        name: "FK_GroupVerbumUser_Users_usersId",
                        column: x => x.usersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupVerbumUser_groups_groupsid",
                        column: x => x.groupsid,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("5cb468ef-185b-44a0-9162-46f2a69eb9af"), "General" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupVerbumUser_usersId",
                table: "GroupVerbumUser",
                column: "usersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupVerbumUser");

            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("5cb468ef-185b-44a0-9162-46f2a69eb9af"));

            migrationBuilder.AddColumn<Guid>(
                name: "Groupid",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("ed0a9c1b-349f-47c8-8eff-17b5c41e3c68"), "General" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Groupid",
                table: "Users",
                column: "Groupid");

            migrationBuilder.CreateIndex(
                name: "IX_groups_UserId",
                table: "groups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_groups_Users_UserId",
                table: "groups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_groups_Groupid",
                table: "Users",
                column: "Groupid",
                principalTable: "groups",
                principalColumn: "id");
        }
    }
}
