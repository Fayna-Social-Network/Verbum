using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Domain.Groups.GroupsVotes
{
    public class GroupVote
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }

        public Guid GroupMessageId { get; set; }
        public GroupMessage? groupMessage { get; set; } 

        public List<VoteItem>? voteItems { get; set; }

    }
}
