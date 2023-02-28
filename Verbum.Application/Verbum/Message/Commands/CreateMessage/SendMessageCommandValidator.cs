using FluentValidation;

namespace Verbum.Application.Verbum.Message.Commands.CreateMessage
{
    public class SendMessageCommandValidator :AbstractValidator<SendMessageCommand>
    {
        public SendMessageCommandValidator() {

            RuleFor(sendMessageCommand => sendMessageCommand.Text).NotNull();
            RuleFor(sendMessageCommand => sendMessageCommand.Seller).NotEqual(Guid.Empty);
            RuleFor(sendMessageCommand => sendMessageCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(SendMessageCommand => SendMessageCommand.ChatId).NotEqual(Guid.Empty);
        }
    }
}
