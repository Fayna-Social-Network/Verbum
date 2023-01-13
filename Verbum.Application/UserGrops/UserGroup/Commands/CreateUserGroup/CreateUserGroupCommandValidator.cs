using FluentValidation;

namespace Verbum.Application.UserGrops.UserGroup.Commands.CreateUserGroup
{
    public class CreateUserGroupCommandValidator : AbstractValidator<CreateUserGroupCommand>
    {
        public CreateUserGroupCommandValidator()
        {
            RuleFor(a => a.GroupName).NotEmpty();
            RuleFor(a => a.GroupTheme).NotEmpty();
            RuleFor(a => a.isClosedGroup).Must(a => a == true || a == false);
            RuleFor(a => a.UserId).NotEqual(Guid.Empty);
        }
    }
}
