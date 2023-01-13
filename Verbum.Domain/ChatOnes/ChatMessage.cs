using Verbum.Domain.Common;

namespace Verbum.Domain.ChatOnes
{
    public class ChatMessage : Message
    {
        public Guid ChatId { get; set; }
        public Chat? chat { get; set; }

        public List<ChatMessageReaction>? chatMessageReactions { get; set; }
        public ChatImageMessage? chatImageMessage { get; set; }
        public ChatFileMessage? chatFileMessage { get; set; }
        public ChatAudioMessage? chatAudioMessage { get; set; }
        public ChatVideoMessage? chatVideoMessage { get; set; }
    }
}
