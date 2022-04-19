using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    public partial class new_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_fileMessages_MessageId",
                table: "fileMessages");

            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("e60a0646-c860-4fe6-a658-fa177718a55c"));


            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "fileMessages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "fileMessages",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("96f14bb1-ae65-4b57-b5d4-65950098bc4a"), "General" });

            migrationBuilder.CreateIndex(
                name: "IX_fileMessages_MessageId",
                table: "fileMessages",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fileMessages_UserId",
                table: "fileMessages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_fileMessages_Users_UserId",
                table: "fileMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fileMessages_Users_UserId",
                table: "fileMessages");

            migrationBuilder.DropIndex(
                name: "IX_fileMessages_MessageId",
                table: "fileMessages");

            migrationBuilder.DropIndex(
                name: "IX_fileMessages_UserId",
                table: "fileMessages");

            migrationBuilder.DeleteData(
                table: "contactGroups",
                keyColumn: "Id",
                keyValue: new Guid("96f14bb1-ae65-4b57-b5d4-65950098bc4a"));

           
            migrationBuilder.DropColumn(
                name: "Type",
                table: "fileMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "fileMessages");

          
            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("e60a0646-c860-4fe6-a658-fa177718a55c"), "General" });

            migrationBuilder.CreateIndex(
                name: "IX_fileMessages_MessageId",
                table: "fileMessages",
                column: "MessageId");
        }
    }
}
