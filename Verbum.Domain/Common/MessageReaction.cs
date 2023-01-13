
namespace Verbum.Domain.Common
{
    public class MessageReaction
    {

        public Guid Id { get; set; }
        public string? ReactionName { get; set; }
        public int ReactionCount { get; set; }

        public Guid UserId { get; set; }

    }
}
