using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
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
using Verbum.Persistence.EntityTypeConfigurations;

namespace Verbum.Persistence
{
    public class VerbumDbContext :DbContext, IVerbumDbContext
    {
        
        public DbSet<VerbumUser> Users { get; set; } = null!;
        public DbSet<UserContact> UserContacts { get; set; } = null!;
        public DbSet<UserBlackList> UserBlackLists { get; set; } = null!;
        public DbSet<UserFile> usersFiles { get; set; } = null!;

        public DbSet<Chat> chats { get; set; } = null!;
        public DbSet<ChatMessage> chatMessages { get; set; } = null!;
        public DbSet<ChatMessageReaction> chatMessageReactions { get; set; } = null!;
        public DbSet<ChatImageMessage> chatImageMessages { get; set; } = null!;
        public DbSet<ChatAudioMessage> chatAudioMessages { get; set; } = null!;
        public DbSet<ChatVideoMessage> chatVideoMessages { get; set; } = null!;
        public DbSet<ChatFileMessage> chatFileMessages { get; set; } = null!;

        public DbSet<Hobby> UserHobbies { get; set; } = null!;
        public DbSet<PhoneNumber> UserPhoneNumbers { get; set; } = null!;
        public DbSet<SocialNetwork> UserSocialNetworks { get; set; } = null!;
        public DbSet<UserAdress> userAdresses { get; set; } = null!;
        public DbSet<UserDetails> userDetails { get; set; } = null!;
        public DbSet<ContactGroup> userContactGroups { get; set; } = null!;

        public DbSet<Sticker> Stickers { get; set; } = null!;
        public DbSet<StickersGroup> stickersGroups { get; set; } = null!;

        public DbSet<Group> groups { get; set; } = null!;
        public DbSet<GroupThemes> groupsThemes { get; set; } = null!;
        public DbSet<GroupMessage> groupMessages { get; set; } = null!;
        public DbSet<GroupMessageComment> groupMessageComments { get; set; } = null!;
        public DbSet<GroupMessageReaction> groupMessageReactions { get; set; } = null!;
        public DbSet<GroupImageMessage> groupImageMessages { get; set; } = null!;
        public DbSet<GroupAudioMessage> groupAudioMessages { get; set; } = null!;
        public DbSet<GroupVideoMessage> groupVideoMessages { get; set; } = null!;
        public DbSet<GroupFileMessage> groupFileMessages { get; set; } = null!;
        public DbSet<GroupVote> groupVotes { get; set; } = null!;
        public DbSet<VoteItem> voteItems { get; set; } = null!;

        public DbSet<Notification> notifications { get; set; } = null!;


        public VerbumDbContext(DbContextOptions<VerbumDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder) {

            builder.ApplyConfiguration(new GroupVoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
