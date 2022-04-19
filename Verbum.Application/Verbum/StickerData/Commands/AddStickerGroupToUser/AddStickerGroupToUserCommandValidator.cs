using FluentValidation;

namespace Verbum.Application.Verbum.StickerData.Commands.AddStickerGroupToUser
{
    public class AddStickerGroupToUserCommandValidator : AbstractValidator<AddStickerGroupToUserCommand>
    {
        public AddStickerGroupToUserCommandValidator() {
            RuleFor(p => p.StickerGroupId).NotEqual(Guid.Empty);
            RuleFor(p => p.UserId).NotEqual(Guid.Empty);
        }
    }
}
