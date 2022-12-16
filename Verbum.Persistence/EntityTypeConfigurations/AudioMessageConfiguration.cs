using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.MessagesDb;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class AudioMessageConfiguration :IEntityTypeConfiguration<AudioMessage>
    {
        public void Configure(EntityTypeBuilder<AudioMessage> builder) {
            builder.HasOne(m => m.Message)
                .WithOne(a => a.AudioMessage)
                .HasForeignKey<AudioMessage>(a => a.MessageId);

            builder.HasOne(m => m.groupMessage)
                .WithOne(a => a.AudioMessage)
                .HasForeignKey<AudioMessage>(a => a.GroupMessageId);

            builder.HasOne(m => m.GroupMessageComment)
                .WithOne(a => a.AudioMessage)
                .HasForeignKey<AudioMessage>(a => a.GroupCommentId);
                
        }
    }
}
