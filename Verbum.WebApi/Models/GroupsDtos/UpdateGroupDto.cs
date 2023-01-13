namespace Verbum.WebApi.Models.GroupsDtos
{
    public class UpdateGroupDto
    {
        public Guid GroupId { get; set; }
        public string? NewGroupName { get; set; }
        public string? GroupAvatarPath { get; set; }
        public bool isClosed { get; set; }
    }
}
