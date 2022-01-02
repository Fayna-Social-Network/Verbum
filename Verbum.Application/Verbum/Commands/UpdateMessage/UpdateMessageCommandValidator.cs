using FluentValidation;
using Verbum.Application.Verbum.Commands.UpdateMessage;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateMessageCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(update => update.UserId).NotEqual(Guid.Empty);
            RuleFor(update => update.Id).NotEqual(Guid.Empty);
        }
    }
}
