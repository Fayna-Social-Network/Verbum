using Verbum.Domain.MessagesDb;

namespace Verbum.Domain.Groups.GroupsMessages
{
    public class GroupMessageComment : Message
    {
        public Guid MessageId { get; set; }
        public GroupMessages? groupMessages { get; set; } 
    }
}
