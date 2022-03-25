using FluentValidation;

namespace Verbum.Application.Verbum.BlockedUsers.Commands.UnBlockUser
{
    public class UnBlockUserCommandValidator : AbstractValidator<UnBlockUserCommand>
    {
        public UnBlockUserCommandValidator() {
            RuleFor(b => b.UserId).NotEqual(Guid.Empty);
            RuleFor(b => b.BlockId).NotEqual(Guid.Empty);
        }
    }
}
