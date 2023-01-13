using Verbum.Domain.Common;

namespace Verbum.Domain.Groups.GroupsMessages
{
    public class GroupMessageComment : Message
    {
        public Guid MessageId { get; set; }
        public Guid groupMessageId { get; set; }  
        public GroupMessage? groupMessages { get; set; }

        public List<GroupMessageComment>? groupMessageComments { get; set; }
    }
}
