using FluentValidation;

namespace Verbum.Application.Verbum.Commands.CreateMessage
{
    public class CreateMessageCommandValidator :AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidator()
        {
            RuleFor(createMessageCommand =>
                createMessageCommand.Text).NotEmpty();
            RuleFor(createMessageCommand =>
                createMessageCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
