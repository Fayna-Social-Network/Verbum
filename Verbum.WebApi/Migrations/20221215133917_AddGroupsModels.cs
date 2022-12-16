using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    public partial class AddGroupsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HobbyName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "socialNetworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialNetworks", x => x.Id);
                });

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
                name: "ContactGroupVerbumUser",
                columns: table => new
                {
                    ContactGroupsId = table.Column<Guid>(type: "uuid", nullable: false),
                    verbumUsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactGroupVerbumUser", x => new { x.ContactGroupsId, x.verbumUsersId });
                    table.ForeignKey(
                        name: "FK_ContactGroupVerbumUser_contactGroups_ContactGroupsId",
                        column: x => x.ContactGroupsId,
                        principalTable: "contactGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupMessageComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Seller = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupMessageComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "groupMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupThemeId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupVoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Seller = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "groupVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupVotes_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "voteItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    VotesCount = table.Column<long>(type: "bigint", nullable: false),
                    GroupVoteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_voteItems_groupVotes_GroupVoteId",
                        column: x => x.GroupVoteId,
                        principalTable: "groupVotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "audioMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "text", nullable: true),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupCommentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audioMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_audioMessages_groupMessageComments_GroupCommentId",
                        column: x => x.GroupCommentId,
                        principalTable: "groupMessageComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_audioMessages_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: false),
                    isGroupClosed = table.Column<bool>(type: "boolean", nullable: false),
                    isBlockedGroup = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groupsThemes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupsThemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupsThemes_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsOnline = table.Column<bool>(type: "boolean", nullable: false),
                    HubConnectionId = table.Column<string>(type: "text", nullable: true),
                    UserRegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Groupid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_groups_Groupid",
                        column: x => x.Groupid,
                        principalTable: "groups",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Seller = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "UserBlackLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Contact = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlackLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBlackLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Contact = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContacts_contactGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "contactGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContacts_Users_Contact",
                        column: x => x.Contact,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Profession = table.Column<string>(type: "text", nullable: true),
                    Tagline = table.Column<string>(type: "text", nullable: true),
                    About = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fileMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupCommentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fileMessages_groupMessageComments_GroupCommentId",
                        column: x => x.GroupCommentId,
                        principalTable: "groupMessageComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fileMessages_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fileMessages_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fileMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageAlbums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Header = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupCommentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageAlbums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageAlbums_groupMessageComments_GroupCommentId",
                        column: x => x.GroupCommentId,
                        principalTable: "groupMessageComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageAlbums_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageAlbums_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageReactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReactionName = table.Column<string>(type: "text", nullable: true),
                    ReactionCount = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupCommentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageReactions_groupMessageComments_GroupCommentId",
                        column: x => x.GroupCommentId,
                        principalTable: "groupMessageComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageReactions_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageReactions_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "videoMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupCommentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videoMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videoMessages_groupMessageComments_GroupCommentId",
                        column: x => x.GroupCommentId,
                        principalTable: "groupMessageComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_videoMessages_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_videoMessages_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HobbyUserDetails",
                columns: table => new
                {
                    HobbiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    userDetailsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyUserDetails", x => new { x.HobbiesId, x.userDetailsId });
                    table.ForeignKey(
                        name: "FK_HobbyUserDetails_hobbies_HobbiesId",
                        column: x => x.HobbiesId,
                        principalTable: "hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyUserDetails_userDetails_userDetailsId",
                        column: x => x.userDetailsId,
                        principalTable: "userDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Operator = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    UserDetailsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phoneNumbers_userDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "userDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworkUserDetails",
                columns: table => new
                {
                    socialNetworksId = table.Column<Guid>(type: "uuid", nullable: false),
                    userDetailsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworkUserDetails", x => new { x.socialNetworksId, x.userDetailsId });
                    table.ForeignKey(
                        name: "FK_SocialNetworkUserDetails_socialNetworks_socialNetworksId",
                        column: x => x.socialNetworksId,
                        principalTable: "socialNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialNetworkUserDetails_userDetails_userDetailsId",
                        column: x => x.userDetailsId,
                        principalTable: "userDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userAdresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    House = table.Column<string>(type: "text", nullable: true),
                    Apartment = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<int>(type: "integer", nullable: false),
                    UserDetailsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAdresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userAdresses_userDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "userDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: true),
                    ImageAlbumId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                    table.ForeignKey(
                        name: "FK_Images_ImageAlbums_ImageAlbumId",
                        column: x => x.ImageAlbumId,
                        principalTable: "ImageAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "contactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { new Guid("624aade5-afa1-460b-aa4d-33515409b6ff"), "General" });

            migrationBuilder.CreateIndex(
                name: "IX_audioMessages_GroupCommentId",
                table: "audioMessages",
                column: "GroupCommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_audioMessages_GroupMessageId",
                table: "audioMessages",
                column: "GroupMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_audioMessages_MessageId",
                table: "audioMessages",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactGroupVerbumUser_verbumUsersId",
                table: "ContactGroupVerbumUser",
                column: "verbumUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_fileMessages_GroupCommentId",
                table: "fileMessages",
                column: "GroupCommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fileMessages_GroupMessageId",
                table: "fileMessages",
                column: "GroupMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fileMessages_MessageId",
                table: "fileMessages",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fileMessages_UserId",
                table: "fileMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMessageComments_MessageId",
                table: "groupMessageComments",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMessages_GroupThemeId",
                table: "groupMessages",
                column: "GroupThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_groups_UserId",
                table: "groups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_groupsThemes_GroupId",
                table: "groupsThemes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_groupVotes_GroupMessageId",
                table: "groupVotes",
                column: "GroupMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HobbyUserDetails_userDetailsId",
                table: "HobbyUserDetails",
                column: "userDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageAlbums_GroupCommentId",
                table: "ImageAlbums",
                column: "GroupCommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageAlbums_GroupMessageId",
                table: "ImageAlbums",
                column: "GroupMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageAlbums_MessageId",
                table: "ImageAlbums",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageAlbumId",
                table: "Images",
                column: "ImageAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReactions_GroupCommentId",
                table: "MessageReactions",
                column: "GroupCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReactions_GroupMessageId",
                table: "MessageReactions",
                column: "GroupMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReactions_MessageId",
                table: "MessageReactions",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_phoneNumbers_UserDetailsId",
                table: "phoneNumbers",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworkUserDetails_userDetailsId",
                table: "SocialNetworkUserDetails",
                column: "userDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Stickers_stickersGroupId",
                table: "Stickers",
                column: "stickersGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StickersGroupVerbumUser_verbumUsersId",
                table: "StickersGroupVerbumUser",
                column: "verbumUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_userAdresses_UserDetailsId",
                table: "userAdresses",
                column: "UserDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBlackLists_UserId",
                table: "UserBlackLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_Contact",
                table: "UserContacts",
                column: "Contact");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_GroupId",
                table: "UserContacts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_UserId",
                table: "userDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Groupid",
                table: "Users",
                column: "Groupid");

            migrationBuilder.CreateIndex(
                name: "IX_videoMessages_GroupCommentId",
                table: "videoMessages",
                column: "GroupCommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_videoMessages_GroupMessageId",
                table: "videoMessages",
                column: "GroupMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_videoMessages_MessageId",
                table: "videoMessages",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_voteItems_GroupVoteId",
                table: "voteItems",
                column: "GroupVoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactGroupVerbumUser_Users_verbumUsersId",
                table: "ContactGroupVerbumUser",
                column: "verbumUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_groupMessageComments_groupMessages_MessageId",
                table: "groupMessageComments",
                column: "MessageId",
                principalTable: "groupMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_groupMessages_groupsThemes_GroupThemeId",
                table: "groupMessages",
                column: "GroupThemeId",
                principalTable: "groupsThemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_audioMessages_Messages_MessageId",
                table: "audioMessages",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_groups_Users_UserId",
                table: "groups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groups_Users_UserId",
                table: "groups");

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
                name: "voteItems");

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
                name: "groupVotes");

            migrationBuilder.DropTable(
                name: "groupMessageComments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "groupMessages");

            migrationBuilder.DropTable(
                name: "groupsThemes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}
