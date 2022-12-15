
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Domain
{
    public class Group
    {
        public Guid id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public bool isGroupClosed { get; set; }
        public bool isBlockedGroup { get; set; }
        public Guid UserId { get; set; }

        public VerbumUser? User { get; set; }
        public ICollection<VerbumUser>? users { get; set; } 
        public ICollection<GroupsThemes>? groupsThemes { get; set; } 
    }
}
