

namespace Verbum.Domain.Groups.GroupsMessages
{
    public class GroupsThemes
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } 
        public Guid GroupId { get; set; }

        public Group? group { get; set; }
        public ICollection<GroupMessages>? groupMessages { get; set; }
    }
}
