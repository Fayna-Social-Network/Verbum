using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder) {
            builder.HasOne<VerbumUser>(a => a.User)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserId)
                .HasForeignKey(d => d.Seller);
        }

    }
}
