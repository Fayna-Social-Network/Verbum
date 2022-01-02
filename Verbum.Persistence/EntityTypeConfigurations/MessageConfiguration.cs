using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder) {
            builder.HasOne<User>(a => a.User)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserId);
        }

    }
}
