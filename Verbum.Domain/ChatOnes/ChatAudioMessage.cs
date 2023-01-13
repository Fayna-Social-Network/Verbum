using Verbum.Domain.Common;

namespace Verbum.Domain.ChatOnes
{
    public class ChatAudioMessage : AudioMessage
    {
        public Guid ChatMessageId { get; set; }
        public ChatMessage? chatMessage { get; set; }
    }
}
