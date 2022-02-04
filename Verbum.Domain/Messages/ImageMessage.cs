
namespace Verbum.Domain
{
    public class ImageMessage
    {
        public Guid id  { get; set; }
        public string? Header { get; set; }
        public string? Path { get; set; }
        public string? Description { get; set; }

        public Guid MessageId { get; set; }
        public Messages? Message { get; set; }
       

    }
}
