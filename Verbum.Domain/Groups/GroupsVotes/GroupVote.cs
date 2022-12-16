using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Domain.Groups.GroupsVotes
{
    public class GroupVote
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }

        public Guid GroupMessageId { get; set; }
        public GroupMessages? groupMessage { get; set; } 

        public ICollection<VoteItem>? voteItems { get; set; }

    }
}
