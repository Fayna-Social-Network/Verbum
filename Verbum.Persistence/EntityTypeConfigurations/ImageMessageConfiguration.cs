using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.MessagesDb;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class ImageMessageConfiguration :IEntityTypeConfiguration<ImageMessage>
    {
        public void Configure(EntityTypeBuilder<ImageMessage> builder) {
            builder.HasOne(i => i.ImageAlbum)
                .WithMany(p => p.ImageMessages)
                .HasForeignKey(im => im.ImageAlbumId);
        }
    }
}
