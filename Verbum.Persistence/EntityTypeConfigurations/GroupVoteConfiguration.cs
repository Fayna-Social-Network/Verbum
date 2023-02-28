using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.Groups.GroupsVotes;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class GroupVoteConfiguration :IEntityTypeConfiguration<GroupVote>
    {
        public void Configure(EntityTypeBuilder<GroupVote> builder) 
        {
            builder.HasOne(m => m.groupMessage)
                .WithOne(a => a.groupVote)
                .HasForeignKey<GroupVote>(a => a.GroupMessageId);
        }
    }
}
