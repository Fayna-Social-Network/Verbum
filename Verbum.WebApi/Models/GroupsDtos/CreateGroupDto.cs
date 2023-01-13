namespace Verbum.WebApi.Models.GroupsDtos
{
    public class CreateGroupDto 
    {
        public string? GroupName { get; set; }
        public string? GroupAvatarPath { get; set; }
        public string? GroupTheme { get; set; }
        public bool isClosedGroup { get; set; }
    }
}
