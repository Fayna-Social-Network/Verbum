using Verbum.Domain.Common;

namespace Verbum.Domain.ChatOnes
{
    public class ChatVideoMessage : VideoMessage
    {
        public Guid ChatMessageId { get; set; }
        public ChatMessage? chatMessage { get; set; }
    }
}
