using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Domain.MessagesDb
{
    public class MessageDependencies
    {
        public Guid MessageId { get; set; }
        public Messages? Message { get; set; }

        public Guid GroupMessageId { get; set; }
        public GroupMessages? groupMessage { get; set; }

        public Guid GroupCommentId { get; set; }
        public GroupMessageComment? GroupMessageComment { get; set; }
    }
}
