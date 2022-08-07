namespace Verbum.WebApi.Models.Messages
{
    public class CreateFileMessageDto
    {
        public string? Path { get; set; }
        public string? Type { get; set; }
        public Guid UserId { get; set; }
    }
}
