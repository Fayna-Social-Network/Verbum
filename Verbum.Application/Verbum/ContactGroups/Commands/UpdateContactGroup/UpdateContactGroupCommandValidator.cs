using FluentValidation;

namespace Verbum.Application.Verbum.ContactGroups.Commands.UpdateContactGroup
{
    public class UpdateContactGroupCommandValidator : AbstractValidator<UpdateContactGroupCommand>
    {
        public UpdateContactGroupCommandValidator() {
            RuleFor(o => o.GroupId).NotEqual(Guid.Empty);
            RuleFor(o => o.NewGroupName).NotEmpty();
        }
    }
}
