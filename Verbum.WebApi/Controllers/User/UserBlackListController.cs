using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.BlockedUsers.Commands.BlockUser;
using Verbum.Application.Verbum.BlockedUsers.Commands.UnBlockUser;

namespace Verbum.WebApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class UserBlackListController : BaseController
    {
        [Authorize]
        [HttpPost("{id}")]
        public async Task<ActionResult<Guid>> AddUserToBlackList(Guid id) {
            var command = new AddUserToBlackListCommand
            {
                UserToBlockId = id,
                UserId = UserId
            };
            var vw = await Mediator.Send(command);
            return Ok(vw);
        }

        [Authorize]
        [HttpDelete("{BlockId}")]
        public async Task<ActionResult> UnBlockUser(Guid BlockId) {

            var command = new UnBlockUserCommand
            {
                BlockId = BlockId,
                UserId = UserId
            };

            await Mediator.Send(command);

            return Ok();
        }

    }
}
