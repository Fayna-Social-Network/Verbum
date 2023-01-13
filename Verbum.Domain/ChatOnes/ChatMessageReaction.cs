using Verbum.Domain.Common;

namespace Verbum.Domain.ChatOnes
{
    public class ChatMessageReaction : MessageReaction
    {
        public Guid ChatMessageId { get; set; }
        public ChatMessage? chatMessage { get; set; }
    }
}
