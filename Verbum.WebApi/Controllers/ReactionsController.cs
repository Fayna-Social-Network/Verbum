using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.Reactions.Commands.AddReaction;
using Verbum.Application.Verbum.Reactions.Queries.GetReactionsQuery;
using Verbum.WebApi.Models.Reactions;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]

    [Route("api/[controller]")]
    [ApiController]
    public class ReactionsController : BaseController
    {

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddReactionToMessage(AddReactionDto dto) {
            var command = new AddReactionCommand
            {
                MessageId = dto.MessageId,
                ReactionName = dto.ReactionName,
                UserId = UserId
            };
            var vm  = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpGet("{messageId}")]
        [Authorize]
        public async Task<ActionResult<ReactionsVm>> GetReactions(Guid messageId) {
            var query = new GetReactionsQuery
            {
                MessageId = messageId
            };
            return await Mediator.Send(query);
        }
    }
}
