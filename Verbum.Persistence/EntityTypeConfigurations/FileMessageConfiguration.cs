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
        }
    }
}
