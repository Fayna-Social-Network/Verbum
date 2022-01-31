using MediatR;

namespace Verbum.Application.Verbum.Reactions.Commands.AddReaction
{
    public class AddReactionCommand :IRequest
    {
        public Guid MessageId { get; set; }
        public string? ReactionName { get; set; }
        public Guid UserId { get; set; }
    }
}
