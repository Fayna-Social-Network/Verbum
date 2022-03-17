using FluentValidation;

namespace Verbum.Application.Verbum.ContactGroups.Commands.DeleteContactGroup
{
    public class DeleteContactGroupCommandValidator : AbstractValidator<DeleteContactGroupCommand>
    {
        public DeleteContactGroupCommandValidator() {
            RuleFor(g => g.Id).NotEqual(Guid.Empty);
            RuleFor(g => g.UserId).NotEqual(Guid.Empty);
        }
    }
}
