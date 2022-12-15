namespace Verbum.Domain.MessagesDb
{
    public class VideoMessage : MessageDependencies
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        
    }
}