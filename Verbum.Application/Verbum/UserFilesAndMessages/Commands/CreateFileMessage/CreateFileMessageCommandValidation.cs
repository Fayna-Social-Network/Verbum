using FluentValidation;

namespace Verbum.Application.Verbum.UserFilesAndMessages.Commands.CreateFileMessage
{
    public class CreateFileMessageCommandValidation :AbstractValidator<CreateFileMessageCommand>
    {
        public CreateFileMessageCommandValidation() {
            RuleFor(f => f.Name).NotNull();
            RuleFor(f => f.Path).NotNull();
            RuleFor(f => f.Seller).NotEqual(Guid.Empty);
            RuleFor(f => f.UserId).NotEqual(Guid.Empty);
        }
    }
}
