using FluentValidation;

namespace Verbum.Application.Verbum.AudioMessages.Commands.AddAudioMessage
{
    public class AddAudioMessageCommandValidator :AbstractValidator<AddAudioMessageCommand>
    {
        public AddAudioMessageCommandValidator() {
            RuleFor(a => a.UserId).NotEqual(Guid.Empty);
            RuleFor(a => a.SellerId).NotEqual(Guid.Empty);
            RuleFor(a => a.ChatId).NotEqual(Guid.Empty);
        }
    }
}
