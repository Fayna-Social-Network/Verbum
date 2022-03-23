using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "stickersGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stickersGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stickers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    StickerGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    stickersGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stickers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stickers_stickersGroups_stickersGroupId",
                        column: x => x.stickersGroupId,
                        principalTable: "stickersGroups",
                        principalColumn: "Id");
                });

    

            migrationBuilder.CreateTable(
                name: "StickersGroupVerbumUser",
                columns: table => new
                {
                    stickersGroupsId = table.Column<Guid>(type: "uuid", nullable: false),
                    verbumUsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StickersGroupVerbumUser", x => new { x.stickersGroupsId, x.verbumUsersId });
                    table.ForeignKey(
                        name: "FK_StickersGroupVerbumUser_stickersGroups_stickersGroupsId",
                        column: x => x.stickersGroupsId,
                        principalTable: "stickersGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StickersGroupVerbumUser_Users_verbumUsersId",
                        column: x => x.verbumUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

         

           

            migrationBuilder.CreateIndex(
                name: "IX_Stickers_stickersGroupId",
                table: "Stickers",
                column: "stickersGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StickersGroupVerbumUser_verbumUsersId",
                table: "StickersGroupVerbumUser",
                column: "verbumUsersId");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audioMessages");

            migrationBuilder.DropTable(
                name: "ContactGroupVerbumUser");

            migrationBuilder.DropTable(
                name: "fileMessages");

            migrationBuilder.DropTable(
                name: "HobbyUserDetails");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "MessageReactions");

            migrationBuilder.DropTable(
                name: "phoneNumbers");

            migrationBuilder.DropTable(
                name: "SocialNetworkUserDetails");

            migrationBuilder.DropTable(
                name: "Stickers");

            migrationBuilder.DropTable(
                name: "StickersGroupVerbumUser");

            migrationBuilder.DropTable(
                name: "userAdresses");

            migrationBuilder.DropTable(
                name: "UserBlackLists");

            migrationBuilder.DropTable(
                name: "UserContacts");

            migrationBuilder.DropTable(
                name: "videoMessages");

            migrationBuilder.DropTable(
                name: "hobbies");

            migrationBuilder.DropTable(
                name: "ImageAlbums");

            migrationBuilder.DropTable(
                name: "socialNetworks");

            migrationBuilder.DropTable(
                name: "stickersGroups");

            migrationBuilder.DropTable(
                name: "userDetails");

            migrationBuilder.DropTable(
                name: "contactGroups");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
