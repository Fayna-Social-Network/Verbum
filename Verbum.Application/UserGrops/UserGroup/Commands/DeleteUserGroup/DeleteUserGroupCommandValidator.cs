using FluentValidation;

namespace Verbum.Application.UserGrops.UserGroup.Commands.DeleteUserGroup
{
    public class DeleteUserGroupCommandValidator : AbstractValidator<DeleteUserGroupCommand>
    {
        public DeleteUserGroupCommandValidator() 
        {
            RuleFor(g => g.GroupId).NotEqual(Guid.Empty);
            RuleFor(g => g.UserId).NotEqual(Guid.Empty);
        }
    }
}
