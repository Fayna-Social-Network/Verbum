using FluentValidation;

namespace Verbum.Application.Verbum.StickerData.Queries.GetStickersByStickerGroup
{
    public class GetStickerByStickerGroupQueryValidator :AbstractValidator<GetStickerByStickerGroupQuery>
    {
        public GetStickerByStickerGroupQueryValidator() {
            RuleFor(x => x.StickersGroupId).NotEqual(Guid.Empty);
        }
    }
}
