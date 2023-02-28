using Microsoft.EntityFrameworkCore;
using Verbum.Domain;
using Verbum.Domain.ChatOnes;
using Verbum.Domain.Groups;
using Verbum.Domain.Groups.GroupChatMessages;
using Verbum.Domain.Groups.GroupsVotes;
using Verbum.Domain.Notifications;
using Verbum.Domain.Stikers;
using Verbum.Domain.UserFilesTable;
using Verbum.Domain.Users;
using Verbum.Domain.Users.Details;

namespace Verbum.Application.Interfaces
{
    public interface IVerbumDbContext
    {
        DbSet<ChatMessage> chatMessages { get; set; }
        DbSet<UserFile> usersFiles { get; set; }
        DbSet<VerbumUser> Users { get; set; }
        DbSet<UserContact> UserContacts { get; set; }
        DbSet<UserBlackList> UserBlackLists { get; set; }
        DbSet<Chat> chats { get; set; }
        DbSet<ChatMessageReaction> chatMessageReactions { get; set; }
        DbSet<ChatImageMessage> chatImageMessages { get; set; }
        DbSet<ChatAudioMessage> chatAudioMessages { get; set; }
        DbSet<ChatVideoMessage> chatVideoMessages { get; set; }
        DbSet<ChatFileMessage> chatFileMessages { get; set; }
        DbSet<Hobby> UserHobbies { get; set; }
        DbSet<PhoneNumber> UserPhoneNumbers { get; set; }
        DbSet<SocialNetwork> UserSocialNetworks { get; set; }
        DbSet<UserAdress> userAdresses { get; set; }
        DbSet<UserDetails> userDetails { get; set; }
        DbSet<ContactGroup> userContactGroups { get; set; }
        DbSet<Sticker> Stickers { get; set; }
        DbSet<StickersGroup> stickersGroups { get; set; }
        DbSet<Group> groups { get; set; }
        DbSet<GroupMessage> groupMessages { get; set; }
        DbSet<GroupMessageReaction> groupMessageReactions { get; set; }
        DbSet<GroupImageMessage> groupImageMessages { get; set; }
        DbSet<GroupAudioMessage> groupAudioMessages { get; set; }
        DbSet<GroupVideoMessage> groupVideoMessages { get; set; }
        DbSet<GroupFileMessage> groupFileMessages { get; set; }
        DbSet<GroupMessageComment> groupMessageComments { get; set; }
        DbSet<GroupThemes> groupsThemes { get; set; }
        DbSet<GroupVote> groupVotes { get; set; }
        DbSet<VoteItem> voteItems { get; set; }
        DbSet<Notification> notifications { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
