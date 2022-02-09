namespace Verbum.Domain.MessagesDb
{
    public class AudioMessage
    {
        public Guid Id { get; set; }
        public string? path { get; set; }

        public Guid MessageId { get; set; }
        public Messages? Message { get; set; }
    }
}
