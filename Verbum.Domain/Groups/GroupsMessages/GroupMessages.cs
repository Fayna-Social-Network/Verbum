using Verbum.Domain.Groups.GroupsVotes;
using Verbum.Domain.MessagesDb;

namespace Verbum.Domain.Groups.GroupsMessages
{
    public class GroupMessages: Message
    {
        public Guid GroupThemeId { get; set; }
        public virtual GroupsThemes? GroupTheme { get; set; }

        public GroupVote? groupVote { get; set; }
        public ICollection<GroupMessageComment>? Comments { get; set; }
    }
}
