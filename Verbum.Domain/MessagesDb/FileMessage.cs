namespace Verbum.Domain.MessagesDb
{
    public class FileMessage : MessageDependencies
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }

        public virtual VerbumUser? User { get; set; }
    }
}