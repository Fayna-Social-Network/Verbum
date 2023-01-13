using Verbum.Domain.Groups;

namespace Verbum.Domain
{
    public class Group
    {
        public Guid id { get; set; }
        public string? GroupName { get; set; }
        public string? GroupAvatarPath { get; set; }
        public bool isGroupClosed { get; set; }
        public bool isBlockedGroup { get; set; }
        public bool Favorites { get; set; }
        public Guid UserId { get; set; }

        public List<VerbumUser>? users { get; set; } 
        public List<GroupThemes>? groupThemes { get; set; } 
    }
}
