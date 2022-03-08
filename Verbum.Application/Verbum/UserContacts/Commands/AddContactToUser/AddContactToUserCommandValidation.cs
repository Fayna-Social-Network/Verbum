using FluentValidation;

namespace Verbum.Application.Verbum.UserContacts.Commands.AddContactToUser
{
    public class AddContactToUserCommandValidation :AbstractValidator<AddContactToUserCommand>
    {
        public AddContactToUserCommandValidation() {
            RuleFor(x => x.Contact).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Group).NotEmpty();
        }
    }
}
