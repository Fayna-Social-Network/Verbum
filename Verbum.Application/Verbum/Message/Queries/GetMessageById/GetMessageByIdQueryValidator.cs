using FluentValidation;

namespace Verbum.Application.Verbum.Message.Queries.GetMessageById
{
    public class GetMessageByIdQueryValidator :AbstractValidator<GetMessageByIdQuery>
    {

        public GetMessageByIdQueryValidator() {
            RuleFor(x => x.MessageId).NotEqual(Guid.Empty);
        }
    }
}
