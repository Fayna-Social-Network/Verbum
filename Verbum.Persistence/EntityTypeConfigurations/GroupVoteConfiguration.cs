using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.Groups.GroupsMessages;
using Verbum.Domain.Groups.GroupsVotes;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class GroupVoteConfiguration : IEntityTypeConfiguration<GroupVote>
    {
        public void Configure(EntityTypeBuilder<GroupVote> builder)
        {
            builder.HasOne(a => a.groupMessage)
                .WithOne(d => d.groupVote)
                .HasForeignKey<GroupVote>(d => d.GroupMessageId);

        }
    }
}
