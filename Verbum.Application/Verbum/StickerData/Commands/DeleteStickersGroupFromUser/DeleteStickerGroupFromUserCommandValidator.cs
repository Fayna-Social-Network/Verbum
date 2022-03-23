using FluentValidation;

namespace Verbum.Application.Verbum.StickerData.Commands.DeleteStickersGroupFromUser
{
    public class DeleteStickerGroupFromUserCommandValidator :AbstractValidator<DeleteStickersGroupFromUserCommand>
    {
        public DeleteStickerGroupFromUserCommandValidator() {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.StickerGroupId).NotEqual(Guid.Empty);
        }
    }
}
