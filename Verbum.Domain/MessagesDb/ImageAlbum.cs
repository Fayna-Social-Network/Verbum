
namespace Verbum.Domain.MessagesDb
{
    public class ImageAlbum
    {
        public Guid Id { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }

        public Guid MessageId { get; set; }
        public Messages? Message { get; set; }

        public virtual ICollection<ImageMessage>? ImageMessages { get; set; }
    }
}
