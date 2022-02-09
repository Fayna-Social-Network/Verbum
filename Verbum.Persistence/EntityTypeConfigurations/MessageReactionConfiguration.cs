using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.MessagesDb;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class MessageReactionConfiguration :IEntityTypeConfiguration<MessageReaction>
    {
        public void Configure(EntityTypeBuilder<MessageReaction> builder) {
            builder.HasOne<Messages>(m => m.Message)
                .WithMany(n => n.MessageReactions)
                .HasForeignKey(f => f.MessageId);
       
        }
    }
}
