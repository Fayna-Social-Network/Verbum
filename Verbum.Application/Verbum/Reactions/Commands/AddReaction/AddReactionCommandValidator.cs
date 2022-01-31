using FluentValidation;

namespace Verbum.Application.Verbum.Reactions.Commands.AddReaction
{
    public class AddReactionCommandValidator :AbstractValidator<AddReactionCommand>
    {
        public AddReactionCommandValidator() {
            RuleFor(f => f.MessageId).NotEqual(Guid.Empty);
            RuleFor(f => f.ReactionName).NotEmpty();
            RuleFor(f => f.UserId).NotEqual(Guid.Empty);  
        }
    }
}
