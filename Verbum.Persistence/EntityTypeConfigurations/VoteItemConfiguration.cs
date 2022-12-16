using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.Groups.GroupsVotes;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class VoteItemConfiguration : IEntityTypeConfiguration<VoteItem>
    {
        public void Configure(EntityTypeBuilder<VoteItem> builder)
        {
            builder.HasOne(a => a.groupVote)
                .WithMany(d => d.voteItems)
                .HasForeignKey(d => d.GroupVoteId);
        }

    }
}
