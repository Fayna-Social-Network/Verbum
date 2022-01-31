using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Domain;
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
       // public DbSet<Image> Images { get; set; } = null!;     

        public VerbumDbContext(DbContextOptions<VerbumDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new UserContactConfiguration());
            builder.ApplyConfiguration(new UserBlackListConfiguration());
            builder.ApplyConfiguration(new MessageReactionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
