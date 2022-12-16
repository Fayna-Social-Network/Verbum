
namespace Verbum.Domain.Notifications
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public Guid Author { get; set; }
        public string? Message { get; set; }
        public Guid ObjectId { get; set; }
        public bool isRead { get; set; }
        public DateTime timestamp { get; set; }

        public Guid UserId { get; set; }
        public VerbumUser? User { get; set; }
    }
}
