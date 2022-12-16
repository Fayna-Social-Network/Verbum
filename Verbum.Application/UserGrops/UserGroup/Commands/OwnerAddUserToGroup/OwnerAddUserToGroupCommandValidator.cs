using FluentValidation;

namespace Verbum.Application.UserGrops.UserGroup.Commands.OwnerAddUserToGroup
{
    public class OwnerAddUserToGroupCommandValidator : AbstractValidator<OwnerAddUserToGroupCommand>
    {
        public OwnerAddUserToGroupCommandValidator() 
        {
            RuleFor(c => c.UserId).NotEqual(Guid.Empty);
            RuleFor(c => c.GroupId).NotEqual(Guid.Empty);
            RuleFor(c => c.OwnerGroupId).NotEqual(Guid.Empty);
        }
    }
}
