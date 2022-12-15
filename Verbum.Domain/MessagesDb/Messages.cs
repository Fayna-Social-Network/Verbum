
namespace Verbum.Domain.MessagesDb
{
    public class Messages : Message
    {
        public Guid UserId { get; set; }
        public virtual VerbumUser? User { get; set; }
    }
} 