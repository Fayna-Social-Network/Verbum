
namespace Verbum.Domain.MessagesDb
{
    public class ImageMessage
    {
        public Guid id  { get; set; }
        public string? Path { get; set; }
      
        public Guid ImageAlbumId { get; set; }
        public ImageAlbum? ImageAlbum { get; set; }

    }
}
