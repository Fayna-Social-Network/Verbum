namespace Verbum.Domain
{
    public class VideoMessage
    {
        public Guid Id { get; set; }
        public string? Path { get; set; }
        
        public Guid MessageId {get; set; }
        public Messages? Message {get; set;}
    }
}