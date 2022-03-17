
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.MessagesDb;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class ImageAlbumConfiguration :IEntityTypeConfiguration<ImageAlbum>
    {
        public void Configure(EntityTypeBuilder<ImageAlbum> builder) {
            builder.HasOne(m => m.Message)
                .WithOne(s => s.ImageAlbum)
                .HasForeignKey<ImageAlbum>(i => i.MessageId);
        }
    }
}
