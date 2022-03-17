

namespace Verbum.Application.Hubs.dtos
{
    public class ReactionActivityDto
    {
        public Guid messageId { get; set; }
        public string? reactionName { get; set; }
        public Guid contactId { get; set; }
    }
}
