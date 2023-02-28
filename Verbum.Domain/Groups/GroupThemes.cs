using Verbum.Domain.Groups.GroupChatMessages;

namespace Verbum.Domain.Groups
{
    public class GroupThemes
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid PinnedMessage { get; set; }
        public string? ThemeBackGroundImage { get; set; }
        public Guid GroupId { get; set; }

        public Group? group { get; set; }
        public List<GroupMessage>? groupMessages { get; set; }
    }
}
