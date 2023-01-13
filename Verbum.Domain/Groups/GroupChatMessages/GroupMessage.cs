using Verbum.Domain.Common;
using Verbum.Domain.Groups.GroupChatMessages;
using Verbum.Domain.Groups.GroupsVotes;


namespace Verbum.Domain.Groups.GroupsMessages
{
    public class GroupMessage: Message
    {
        public Guid GroupThemeId { get; set; }
        public virtual GroupThemes? GroupTheme { get; set; }

        public Guid GroupVoteId { get; set; }
        public GroupVote? groupVote { get; set; }
        public List<GroupMessageComment>? Comments { get; set; }
        public List<GroupMessageReaction>? messageReactions { get; set; }

        public GroupAudioMessage? groupAudioMessage { get; set; }
        public GroupFileMessage? groupFileMessage { get; set; }
        public GroupImageMessage? groupImageMessage { get; set; }
        public GroupVideoMessage? groupVideoMessage { get; set; }

    }
}
