using FluentValidation;

namespace Verbum.Application.UserGrops.UserGroup.Commands.UpdateUserGroup
{
    public class UpdateUserGroupCommandValidation : AbstractValidator<UpdateUserGroupCommand>
    {
        public UpdateUserGroupCommandValidation() 
        {
            RuleFor(c => c.GroupId).NotEqual(Guid.Empty);
            RuleFor(c => c.UserId).NotEqual(Guid.Empty);
            RuleFor(c => c.isClosed).NotNull();
            RuleFor(c => c.NewGroupName).NotNull();
        }
    }
}
