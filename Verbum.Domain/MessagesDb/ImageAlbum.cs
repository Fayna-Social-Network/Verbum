
namespace Verbum.Domain.MessagesDb
{
    public class ImageAlbum : MessageDependencies
    {
        public Guid Id { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ImageMessage>? ImageMessages { get; set; }
    }
}
