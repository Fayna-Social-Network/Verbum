
namespace Verbum.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Text { get; set; }
        public DateTime Timestamp { get; set; }

        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

    }
}
