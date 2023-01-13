namespace Verbum.WebApi.Models.GroupsMessageDtos
{
    public class CreateGroupMessageDto
    {
        public Guid GroupId { get; set; }
        public Guid GroupThemeId { get; set; }
        public string? Text { get; set; }
    }
}
