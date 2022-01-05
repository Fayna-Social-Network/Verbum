
namespace Verbum.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public Guid Seller { get; set; } 
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        public Guid UserId { get; set; }
        public virtual VerbumUser? User { get; set; }

    }
}
