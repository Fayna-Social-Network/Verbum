using FluentValidation;

namespace Verbum.Application.Verbum.Message.Commands.SetMessageIsRead
{
    public class SetMessageIsReadCommandValidator :AbstractValidator<SetMessageIsReadCommand>
    {
        public SetMessageIsReadCommandValidator() {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
