namespace Verbum.Domain.MessagesDb
{
    public class VideoMessage
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        
        public Guid MessageId {get; set; }
        public Messages? Message {get; set;}
    }
}