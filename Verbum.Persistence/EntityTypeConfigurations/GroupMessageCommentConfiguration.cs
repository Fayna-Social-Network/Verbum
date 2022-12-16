using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class GroupMessageCommentConfiguration : IEntityTypeConfiguration<GroupMessageComment>
    {
        public void Configure(EntityTypeBuilder<GroupMessageComment> builder)
        {
            builder.HasOne(a => a.groupMessages)
                .WithMany(d => d.Comments)
                .HasForeignKey(d => d.MessageId);

        }

    }
}
