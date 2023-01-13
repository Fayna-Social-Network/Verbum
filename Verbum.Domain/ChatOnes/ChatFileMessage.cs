
using Verbum.Domain.Common;
using Verbum.Domain.UserFilesTable;

namespace Verbum.Domain.ChatOnes
{
    public class ChatFileMessage : FileMessage
    {
        public Guid ChatMessageId { get; set; }
        public ChatMessage? chatMessage { get; set; }
    }
}
