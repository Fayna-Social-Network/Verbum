using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class ImageMessageConfiguration :IEntityTypeConfiguration<ImageMessage>
    {
        public void Configure(EntityTypeBuilder<ImageMessage> builder) {
            builder.HasOne<Messages>(m => m.Message)
                .WithMany(i => i.ImageMessages)
                .HasForeignKey(m => m.MessageId);
        }
    }
}
