using Verbum.Domain.MessagesDb;

namespace Verbum.WebApi.Models.Messages
{
    public class MessageImagesDto
    {
        public Guid Id { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }

        public Guid MessageId { get; set; }
        public List<ImageMessage>? imageMessages { get; set; }
    }
}
