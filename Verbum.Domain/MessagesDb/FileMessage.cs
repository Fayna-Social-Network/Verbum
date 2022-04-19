namespace Verbum.Domain.MessagesDb
{
    public class FileMessage
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }

        public Guid MessageId { get; set; }
        public virtual Messages? Message { get; set; }
        public virtual VerbumUser? User { get; set; }
    }
}