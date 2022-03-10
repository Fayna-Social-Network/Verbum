using FluentValidation;

namespace Verbum.Application.Verbum.ContactGroups.Commands.CreateContactGroup
{
    public class CreateContactGroupCommandValidator :AbstractValidator<CreateContactGroupCommand>
    {
        public CreateContactGroupCommandValidator() {
            RuleFor(x => x.GroupName).NotEmpty();
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
