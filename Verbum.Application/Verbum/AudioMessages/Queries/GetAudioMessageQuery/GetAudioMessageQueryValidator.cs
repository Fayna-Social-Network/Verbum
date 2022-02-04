using FluentValidation;

namespace Verbum.Application.Verbum.AudioMessages.Queries.GetAudioMessageQuery
{
    public class GetAudioMessageQueryValidator :AbstractValidator<GetAudioMessageQuery>
    {
        public GetAudioMessageQueryValidator() {
            RuleFor(a => a.MessageId).NotEqual(Guid.Empty);
        }
    }
}
