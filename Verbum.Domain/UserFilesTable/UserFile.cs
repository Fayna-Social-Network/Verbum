using Verbum.Domain.ChatOnes;
using Verbum.Domain.Groups.GroupChatMessages;

namespace Verbum.Domain.UserFilesTable
{
    public class UserFile
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? PreviewImagePath { get; set; } 

        public Guid UserId { get; set; }
        public VerbumUser? user { get; set; }

        public List<ChatFileMessage>? chatFileMessages { get; set; }
        public List<ChatAudioMessage>? chatAudioMessages { get; set; }
        public List<ChatVideoMessage>? chatVideoMessages { get; set; }
        public List<ChatImageMessage>? chatImageMessages { get; set; }

        public List<GroupFileMessage>? groupFileMessages { get; set; }
        public List<GroupAudioMessage>? groupAudioMessages { get; set; }
        public List<GroupVideoMessage>? groupVideoMessages { get; set; }
        public List<GroupImageMessage>? groupImageMessages { get; set; }
    }
}
