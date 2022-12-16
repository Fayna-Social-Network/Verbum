using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.MessagesDb;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class FileMessageConfiguration : IEntityTypeConfiguration<FileMessage>
    {
        public void Configure(EntityTypeBuilder<FileMessage> builder)
        {
            builder.HasOne<Messages>(m => m.Message)
                .WithOne(f => f.FileMessage)
                .HasForeignKey<FileMessage>(f => f.MessageId);

            builder.HasOne(m => m.groupMessage)
               .WithOne(a => a.FileMessage)
               .HasForeignKey<FileMessage>(a => a.GroupMessageId);

            builder.HasOne(m => m.GroupMessageComment)
                .WithOne(a => a.FileMessage)
                .HasForeignKey<FileMessage>(a => a.GroupCommentId);
        }
    }
}
