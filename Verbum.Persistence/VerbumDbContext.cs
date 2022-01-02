using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.Persistence.EntityTypeConfigurations;

namespace Verbum.Persistence
{
    public class VerbumDbContext :DbContext, IVerbumDbContext
    {
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserContact> UserContacts { get; set; } = null!;

        public VerbumDbContext(DbContextOptions<VerbumDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new MessageConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
