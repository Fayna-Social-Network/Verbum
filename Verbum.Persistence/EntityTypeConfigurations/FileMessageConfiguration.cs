using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class FileMessageConfiguration : IEntityTypeConfiguration<FileMessage>
    {
        public void Configure(EntityTypeBuilder<FileMessage> builder)
        {
            builder.HasOne<Messages>(m => m.Message)
                .WithMany(f => f.FileMessages)
                .HasForeignKey(m => m.MessageId);
        }
    }
}
