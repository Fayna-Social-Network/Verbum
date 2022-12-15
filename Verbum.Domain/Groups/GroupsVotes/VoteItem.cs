
namespace Verbum.Domain.Groups.GroupsVotes
{
    public class VoteItem
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public uint VotesCount { get; set; }

        public Guid GroupVoteId { get; set; }
        public GroupVote? groupVote { get; set; }
    }
}
