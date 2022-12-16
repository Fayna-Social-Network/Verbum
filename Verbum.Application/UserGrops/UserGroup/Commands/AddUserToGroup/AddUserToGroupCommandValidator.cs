using FluentValidation;

namespace Verbum.Application.UserGrops.UserGroup.Commands.AddUserToGroup
{
    public class AddUserToGroupCommandValidator : AbstractValidator<AddUserToGroupCommand>
    {
        public AddUserToGroupCommandValidator() 
        {
            RuleFor(u => u.GroupId).NotEqual(Guid.Empty);
            RuleFor(u => u.UserId).NotEqual(Guid.Empty);
        }
    }
}
