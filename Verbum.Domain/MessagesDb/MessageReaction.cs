
namespace Verbum.Domain.MessagesDb
{
    public class MessageReaction : MessageDependencies
    {
        public Guid Id { get; set; }
        public string? ReactionName { get; set; }
        public int ReactionCount { get; set; }
        
        public Guid UserId { get; set; }
     
    }
}
