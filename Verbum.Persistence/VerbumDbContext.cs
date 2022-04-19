using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.Domain.MessagesDb;
using Verbum.Domain.Stikers;
using Verbum.Domain.Users;
using Verbum.Domain.Users.Details;
using Verbum.Persistence.EntityTypeConfigurations;

namespace Verbum.Persistence
{
    public class VerbumDbContext :DbContext, IVerbumDbContext
    {
        public DbSet<Messages> Messages { get; set; } = null!;
        public DbSet<VerbumUser> Users { get; set; } = null!;
        public DbSet<UserContact> UserContacts { get; set; } = null!;
        public DbSet<UserBlackList> UserBlackLists { get; set; } = null!;
        public DbSet<MessageReaction> MessageReactions { get; set; } = null!;
        public DbSet<ImageAlbum> ImageAlbums { get; set; } = null!;
        public DbSet<ImageMessage> Images { get; set; } = null!;
        public DbSet<AudioMessage> audioMessages { get; set; } = null!;
        public DbSet<VideoMessage> videoMessages { get; set; } = null!;
        public DbSet<FileMessage> fileMessages { get; set; } = null!;

        public DbSet<Hobby> hobbies { get; set; } = null!;
        public DbSet<PhoneNumber> phoneNumbers { get; set; } = null!;
        public DbSet<SocialNetwork> socialNetworks { get; set; } = null!;
        public DbSet<UserAdress> userAdresses { get; set; } = null!;
        public DbSet<UserDetails> userDetails { get; set; } = null!;
        public DbSet<ContactGroup> contactGroups { get; set; } = null!;

        public DbSet<Sticker> Stickers { get; set; } = null!;
        public DbSet<StickersGroup> stickersGroups { get; set; } = null!;
       

        public VerbumDbContext(DbContextOptions<VerbumDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new UserContactConfiguration());
            builder.ApplyConfiguration(new UserBlackListConfiguration());
            builder.ApplyConfiguration(new MessageReactionConfiguration());
            builder.ApplyConfiguration(new AudioMessageConfiguration());
            builder.ApplyConfiguration(new FileMessageConfiguration());
            builder.ApplyConfiguration(new ImageMessageConfiguration());
            builder.ApplyConfiguration(new VideMessageConfiguration());
            builder.ApplyConfiguration(new ImageAlbumConfiguration());
            builder.ApplyConfiguration(new ContactGroupConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
