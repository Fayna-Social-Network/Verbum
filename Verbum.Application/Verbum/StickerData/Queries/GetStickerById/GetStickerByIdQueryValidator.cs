using FluentValidation;

namespace Verbum.Application.Verbum.StickerData.Queries.GetStickerById
{
    public class GetStickerByIdQueryValidator :AbstractValidator<GetStickerByIdQuery>
    {
        public GetStickerByIdQueryValidator() {
            RuleFor(x => x.stickerId).NotEqual(Guid.Empty);
        }
    }
}
