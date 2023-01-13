using Verbum.Domain.Common;

namespace Verbum.Domain.ChatOnes
{
    public class ChatImageMessage : ImageMessage
    {
        public Guid ChatMessageId { get; set; }
        public ChatMessage? chatMessage { get; set; }
    }
}
