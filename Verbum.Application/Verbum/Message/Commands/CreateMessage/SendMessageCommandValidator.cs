using FluentValidation;

namespace Verbum.Application.Verbum.Message.Commands.CreateMessage
{
    public class SendMessageCommandValidator :AbstractValidator<SendMessageCommand>
    {
        public SendMessageCommandValidator() {

            RuleFor(sendMessageCommand => sendMessageCommand.Text).NotEmpty();
            RuleFor(sendMessageCommand => sendMessageCommand.Seller).NotEqual(Guid.Empty);
            RuleFor(sendMessageCommand => sendMessageCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
