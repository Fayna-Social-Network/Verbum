using Verbum.Application.Verbum.VideoMessages.Commands.CreateVideoMessage;

namespace Verbum.WebApi.Models.Messages
{
    public class CreateVideoMessageDto 
    {
        public List<VideoFileModel>? videoFiles { get; set; }
        public string Title { get; set; } = string.Empty;
        public Guid ContactId { get; set; }
        public Guid ChatId { get; set; }
    }
}
