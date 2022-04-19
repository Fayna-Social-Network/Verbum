
namespace Verbum.WebApi.Models.Messages
{
    public class CreateVideoMessageDto 
    {
        public string VideoPath { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public Guid ContactId { get; set; }
    }
}
