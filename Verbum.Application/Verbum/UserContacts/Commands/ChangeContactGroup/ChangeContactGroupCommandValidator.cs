using FluentValidation;

namespace Verbum.Application.Verbum.UserContacts.Commands.ChangeContactGroup
{
    public class ChangeContactGroupCommandValidator :AbstractValidator<ChangeContactGroupCommand>
    {
        public ChangeContactGroupCommandValidator() {
            RuleFor(x => x.ContactId).NotEqual(Guid.Empty);
            RuleFor(x => x.ContactName).NotEmpty();
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty); 
        }
    }
}
