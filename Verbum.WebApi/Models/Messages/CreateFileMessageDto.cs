namespace Verbum.WebApi.Models.Messages
{
    public class CreateFileMessageDto
    {
        public string? Text { get; set; }
        public string[]? Paths { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
