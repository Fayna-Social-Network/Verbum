using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Domain.MessagesDb
{
    public class AudioMessage : MessageDependencies
    {
        public Guid Id { get; set; }
        public string? path { get; set; }
    }
}
