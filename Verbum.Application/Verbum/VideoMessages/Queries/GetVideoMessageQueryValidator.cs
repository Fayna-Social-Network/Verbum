using FluentValidation;

namespace Verbum.Application.Verbum.VideoMessages.Queries
{
    public class GetVideoMessageQueryValidator :AbstractValidator<GetVideoMessageQuery>
    {
        public GetVideoMessageQueryValidator() {
            RuleFor(x => x.MessageId).NotEqual(Guid.Empty);
        }
    }
}
