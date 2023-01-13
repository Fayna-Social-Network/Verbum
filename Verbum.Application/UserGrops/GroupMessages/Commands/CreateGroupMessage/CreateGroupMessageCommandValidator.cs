using FluentValidation;


namespace Verbum.Application.UserGrops.GroupMessage.Commands.CreateGroupMessage
{
    public class CreateGroupMessageCommandValidator :AbstractValidator<CreateGroupMessageCommand>
    {
        public CreateGroupMessageCommandValidator() 
        {
            RuleFor(m => m.SellerId).NotEqual(Guid.Empty);
            RuleFor(m => m.GroupId).NotEqual(Guid.Empty);
            RuleFor(m => m.GroupThemeId).NotEqual(Guid.Empty);
            RuleFor(m => m.Text).NotEmpty();
        }
    }
}
