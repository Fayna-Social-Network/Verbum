
namespace Verbum.Domain
{
    public class MessageReaction
    {
        public Guid Id { get; set; }
        public string? ReactionName { get; set; }
        public int ReactionCount { get; set; }
        
        public Guid UserId { get; set; }
        public Guid MessageId { get; set; }
        public virtual Messages? Message { get; set; }
 
    }
}
