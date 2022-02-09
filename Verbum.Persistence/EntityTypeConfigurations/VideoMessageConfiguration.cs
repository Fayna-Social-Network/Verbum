using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.MessagesDb;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class VideMessageConfiguration : IEntityTypeConfiguration<VideoMessage>
    {
        public void Configure(EntityTypeBuilder<VideoMessage> builder)
        {
            builder.HasOne(m => m.Message)
                .WithOne(v => v.VideoMessage)
                .HasForeignKey<VideoMessage>(v => v.MessageId);

        }
    }
}