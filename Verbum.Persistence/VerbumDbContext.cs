using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.Domain.MessagesDb;
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
            base.OnModelCreating(builder);
        }
    }
}
