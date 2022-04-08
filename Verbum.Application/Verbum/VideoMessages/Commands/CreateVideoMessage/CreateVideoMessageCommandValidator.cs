using FluentValidation;

namespace Verbum.Application.Verbum.VideoMessages.Commands.CreateVideoMessage
{
    public class CreateVideoMessageCommandValidator :AbstractValidator<CreateVideoMessageCommand>
    {

        public CreateVideoMessageCommandValidator() {
            RuleFor(x => x.VideoPath).NotEqual(string.Empty);
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.ContactId).NotEqual(Guid.Empty);
        }
    }
}
