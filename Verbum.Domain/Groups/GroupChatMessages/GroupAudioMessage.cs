using Verbum.Domain.Common;
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Domain.Groups.GroupChatMessages
{
    public class GroupAudioMessage : AudioMessage
    {
        public Guid GroupMessageId { get; set; }
        public GroupMessage? groupMessage { get; set; }
    }
}
