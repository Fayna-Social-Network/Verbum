using FluentValidation;

namespace Verbum.Application.Verbum.BlockedUsers.Commands.BlockUser
{
    public class AddUserToBlackListCommandValidator :AbstractValidator<AddUserToBlackListCommand>
    {
        public AddUserToBlackListCommandValidator() {
            RuleFor(c => c.UserId).NotEqual(Guid.Empty);
            RuleFor(c => c.UserToBlockId).NotEqual(Guid.Empty);
        }
    }
}
