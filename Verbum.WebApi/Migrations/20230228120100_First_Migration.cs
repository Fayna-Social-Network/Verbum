using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verbum.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: true),
                    GroupAvatarPath = table.Column<string>(type: "text", nullable: true),
                    isGroupClosed = table.Column<bool>(type: "boolean", nullable: false),
                    isBlockedGroup = table.Column<bool>(type: "boolean", nullable: false),
                    Favorites = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
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
                name: "userContactGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userContactGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserHobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HobbyName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHobbies", x => x.Id);
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
                    UserRegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSocialNetworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialNetworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chatMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Seller = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chatMessages_chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupsThemes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PinnedMessage = table.Column<Guid>(type: "uuid", nullable: false),
                    ThemeBackGroundImage = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_ContactGroupVerbumUser_Users_verbumUsersId",
                        column: x => x.verbumUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactGroupVerbumUser_userContactGroups_ContactGroupsId",
                        column: x => x.ContactGroupsId,
                        principalTable: "userContactGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Author = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    isRead = table.Column<bool>(type: "boolean", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifications_Users_UserId",
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
                        name: "FK_StickersGroupVerbumUser_Users_verbumUsersId",
                        column: x => x.verbumUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StickersGroupVerbumUser_stickersGroups_stickersGroupsId",
                        column: x => x.stickersGroupsId,
                        principalTable: "stickersGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBlackLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Contact = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlockUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlackLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBlackLists_Users_BlockUserId",
                        column: x => x.BlockUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Contact = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ContactBackGroundImage = table.Column<string>(type: "text", nullable: true),
                    IsMuted = table.Column<bool>(type: "boolean", nullable: false),
                    Favorites = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContacts_chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContacts_userContactGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "userContactGroups",
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
                name: "usersFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    PreviewImagePath = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usersFiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chatAudioMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatAudioMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chatAudioMessages_chatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "chatMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chatFileMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatFileMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chatFileMessages_chatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "chatMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chatImageMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatImageMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chatImageMessages_chatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "chatMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chatMessageReactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReactionName = table.Column<string>(type: "text", nullable: true),
                    ReactionCount = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatMessageReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chatMessageReactions_chatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "chatMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chatVideoMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatVideoMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chatVideoMessages_chatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "chatMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_groupMessages_groupsThemes_GroupThemeId",
                        column: x => x.GroupThemeId,
                        principalTable: "groupsThemes",
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
                        name: "FK_HobbyUserDetails_UserHobbies_HobbiesId",
                        column: x => x.HobbiesId,
                        principalTable: "UserHobbies",
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
                        name: "FK_SocialNetworkUserDetails_UserSocialNetworks_socialNetworksId",
                        column: x => x.socialNetworksId,
                        principalTable: "UserSocialNetworks",
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
                name: "UserPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Operator = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    UserDetailsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhoneNumbers_userDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "userDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatAudioMessageUserFile",
                columns: table => new
                {
                    chatAudioMessagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    userFilesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatAudioMessageUserFile", x => new { x.chatAudioMessagesId, x.userFilesId });
                    table.ForeignKey(
                        name: "FK_ChatAudioMessageUserFile_chatAudioMessages_chatAudioMessage~",
                        column: x => x.chatAudioMessagesId,
                        principalTable: "chatAudioMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatAudioMessageUserFile_usersFiles_userFilesId",
                        column: x => x.userFilesId,
                        principalTable: "usersFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatFileMessageUserFile",
                columns: table => new
                {
                    chatFileMessagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    userFilesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatFileMessageUserFile", x => new { x.chatFileMessagesId, x.userFilesId });
                    table.ForeignKey(
                        name: "FK_ChatFileMessageUserFile_chatFileMessages_chatFileMessagesId",
                        column: x => x.chatFileMessagesId,
                        principalTable: "chatFileMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatFileMessageUserFile_usersFiles_userFilesId",
                        column: x => x.userFilesId,
                        principalTable: "usersFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatImageMessageUserFile",
                columns: table => new
                {
                    chatImageMessagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    userFilesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatImageMessageUserFile", x => new { x.chatImageMessagesId, x.userFilesId });
                    table.ForeignKey(
                        name: "FK_ChatImageMessageUserFile_chatImageMessages_chatImageMessage~",
                        column: x => x.chatImageMessagesId,
                        principalTable: "chatImageMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatImageMessageUserFile_usersFiles_userFilesId",
                        column: x => x.userFilesId,
                        principalTable: "usersFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatVideoMessageUserFile",
                columns: table => new
                {
                    chatVideoMessagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    userFilesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatVideoMessageUserFile", x => new { x.chatVideoMessagesId, x.userFilesId });
                    table.ForeignKey(
                        name: "FK_ChatVideoMessageUserFile_chatVideoMessages_chatVideoMessage~",
                        column: x => x.chatVideoMessagesId,
                        principalTable: "chatVideoMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatVideoMessageUserFile_usersFiles_userFilesId",
                        column: x => x.userFilesId,
                        principalTable: "usersFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupAudioMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupAudioMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupAudioMessages_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupFileMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupFileMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupFileMessages_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupImageMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupImageMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupImageMessages_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupMessageComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    groupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageCommentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Seller = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupMessageComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupMessageComments_groupMessageComments_GroupMessageComme~",
                        column: x => x.GroupMessageCommentId,
                        principalTable: "groupMessageComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_groupMessageComments_groupMessages_groupMessageId",
                        column: x => x.groupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupMessageReactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReactionName = table.Column<string>(type: "text", nullable: true),
                    ReactionCount = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupMessageReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupMessageReactions_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupVideoMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupVideoMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupVideoMessages_groupMessages_GroupMessageId",
                        column: x => x.GroupMessageId,
                        principalTable: "groupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
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
                name: "GroupAudioMessageUserFile",
                columns: table => new
                {
                    groupAudioMessagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    userFilesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAudioMessageUserFile", x => new { x.groupAudioMessagesId, x.userFilesId });
                    table.ForeignKey(
                        name: "FK_GroupAudioMessageUserFile_groupAudioMessages_groupAudioMess~",
                        column: x => x.groupAudioMessagesId,
                        principalTable: "groupAudioMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupAudioMessageUserFile_usersFiles_userFilesId",
                        column: x => x.userFilesId,
                        principalTable: "usersFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupFileMessageUserFile",
                columns: table => new
                {
                    groupFileMessagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    userFilesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFileMessageUserFile", x => new { x.groupFileMessagesId, x.userFilesId });
                    table.ForeignKey(
                        name: "FK_GroupFileMessageUserFile_groupFileMessages_groupFileMessage~",
                        column: x => x.groupFileMessagesId,
                        principalTable: "groupFileMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupFileMessageUserFile_usersFiles_userFilesId",
                        column: x => x.userFilesId,
                        principalTable: "usersFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupImageMessageUserFile",
                columns: table => new
                {
                    groupImageMessagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    userFilesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupImageMessageUserFile", x => new { x.groupImageMessagesId, x.userFilesId });
                    table.ForeignKey(
                        name: "FK_GroupImageMessageUserFile_groupImageMessages_groupImageMess~",
                        column: x => x.groupImageMessagesId,
                        principalTable: "groupImageMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupImageMessageUserFile_usersFiles_userFilesId",
                        column: x => x.userFilesId,
                        principalTable: "usersFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupVideoMessageUserFile",
                columns: table => new
                {
                    groupVideoMessagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    userFilesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupVideoMessageUserFile", x => new { x.groupVideoMessagesId, x.userFilesId });
                    table.ForeignKey(
                        name: "FK_GroupVideoMessageUserFile_groupVideoMessages_groupVideoMess~",
                        column: x => x.groupVideoMessagesId,
                        principalTable: "groupVideoMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupVideoMessageUserFile_usersFiles_userFilesId",
                        column: x => x.userFilesId,
                        principalTable: "usersFiles",
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

            migrationBuilder.CreateIndex(
                name: "IX_chatAudioMessages_ChatMessageId",
                table: "chatAudioMessages",
                column: "ChatMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatAudioMessageUserFile_userFilesId",
                table: "ChatAudioMessageUserFile",
                column: "userFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_chatFileMessages_ChatMessageId",
                table: "chatFileMessages",
                column: "ChatMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatFileMessageUserFile_userFilesId",
                table: "ChatFileMessageUserFile",
                column: "userFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_chatImageMessages_ChatMessageId",
                table: "chatImageMessages",
                column: "ChatMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatImageMessageUserFile_userFilesId",
                table: "ChatImageMessageUserFile",
                column: "userFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_chatMessageReactions_ChatMessageId",
                table: "chatMessageReactions",
                column: "ChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_chatMessages_ChatId",
                table: "chatMessages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_chatVideoMessages_ChatMessageId",
                table: "chatVideoMessages",
                column: "ChatMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatVideoMessageUserFile_userFilesId",
                table: "ChatVideoMessageUserFile",
                column: "userFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactGroupVerbumUser_verbumUsersId",
                table: "ContactGroupVerbumUser",
                column: "verbumUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_groupAudioMessages_GroupMessageId",
                table: "groupAudioMessages",
                column: "GroupMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupAudioMessageUserFile_userFilesId",
                table: "GroupAudioMessageUserFile",
                column: "userFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_groupFileMessages_GroupMessageId",
                table: "groupFileMessages",
                column: "GroupMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupFileMessageUserFile_userFilesId",
                table: "GroupFileMessageUserFile",
                column: "userFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_groupImageMessages_GroupMessageId",
                table: "groupImageMessages",
                column: "GroupMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupImageMessageUserFile_userFilesId",
                table: "GroupImageMessageUserFile",
                column: "userFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMessageComments_GroupMessageCommentId",
                table: "groupMessageComments",
                column: "GroupMessageCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMessageComments_groupMessageId",
                table: "groupMessageComments",
                column: "groupMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMessageReactions_GroupMessageId",
                table: "groupMessageReactions",
                column: "GroupMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMessages_GroupThemeId",
                table: "groupMessages",
                column: "GroupThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_groupsThemes_GroupId",
                table: "groupsThemes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupVerbumUser_usersId",
                table: "GroupVerbumUser",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_groupVideoMessages_GroupMessageId",
                table: "groupVideoMessages",
                column: "GroupMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupVideoMessageUserFile_userFilesId",
                table: "GroupVideoMessageUserFile",
                column: "userFilesId");

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
                name: "IX_notifications_UserId",
                table: "notifications",
                column: "UserId");

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
                name: "IX_UserBlackLists_BlockUserId",
                table: "UserBlackLists",
                column: "BlockUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_ChatId",
                table: "UserContacts",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_GroupId",
                table: "UserContacts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_UserId",
                table: "UserContacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_UserId",
                table: "userDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPhoneNumbers_UserDetailsId",
                table: "UserPhoneNumbers",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_usersFiles_UserId",
                table: "usersFiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_voteItems_GroupVoteId",
                table: "voteItems",
                column: "GroupVoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatAudioMessageUserFile");

            migrationBuilder.DropTable(
                name: "ChatFileMessageUserFile");

            migrationBuilder.DropTable(
                name: "ChatImageMessageUserFile");

            migrationBuilder.DropTable(
                name: "chatMessageReactions");

            migrationBuilder.DropTable(
                name: "ChatVideoMessageUserFile");

            migrationBuilder.DropTable(
                name: "ContactGroupVerbumUser");

            migrationBuilder.DropTable(
                name: "GroupAudioMessageUserFile");

            migrationBuilder.DropTable(
                name: "GroupFileMessageUserFile");

            migrationBuilder.DropTable(
                name: "GroupImageMessageUserFile");

            migrationBuilder.DropTable(
                name: "groupMessageComments");

            migrationBuilder.DropTable(
                name: "groupMessageReactions");

            migrationBuilder.DropTable(
                name: "GroupVerbumUser");

            migrationBuilder.DropTable(
                name: "GroupVideoMessageUserFile");

            migrationBuilder.DropTable(
                name: "HobbyUserDetails");

            migrationBuilder.DropTable(
                name: "notifications");

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
                name: "UserPhoneNumbers");

            migrationBuilder.DropTable(
                name: "voteItems");

            migrationBuilder.DropTable(
                name: "chatAudioMessages");

            migrationBuilder.DropTable(
                name: "chatFileMessages");

            migrationBuilder.DropTable(
                name: "chatImageMessages");

            migrationBuilder.DropTable(
                name: "chatVideoMessages");

            migrationBuilder.DropTable(
                name: "groupAudioMessages");

            migrationBuilder.DropTable(
                name: "groupFileMessages");

            migrationBuilder.DropTable(
                name: "groupImageMessages");

            migrationBuilder.DropTable(
                name: "groupVideoMessages");

            migrationBuilder.DropTable(
                name: "usersFiles");

            migrationBuilder.DropTable(
                name: "UserHobbies");

            migrationBuilder.DropTable(
                name: "UserSocialNetworks");

            migrationBuilder.DropTable(
                name: "stickersGroups");

            migrationBuilder.DropTable(
                name: "userContactGroups");

            migrationBuilder.DropTable(
                name: "userDetails");

            migrationBuilder.DropTable(
                name: "groupVotes");

            migrationBuilder.DropTable(
                name: "chatMessages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "groupMessages");

            migrationBuilder.DropTable(
                name: "chats");

            migrationBuilder.DropTable(
                name: "groupsThemes");

            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}
