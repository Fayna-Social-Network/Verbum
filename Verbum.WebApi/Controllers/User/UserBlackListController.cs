using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.BlockedUsers.Commands.BlockUser;
using Verbum.Application.Verbum.BlockedUsers.Commands.UnBlockUser;
using Verbum.Application.Verbum.BlockedUsers.Queries.IsUserBlockedMe;

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

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<isBlockedVm>> IsUserBlockMe(Guid id) {
            
            var query = new IsUserBlockedMeQuery
            {
                CheckUserId = id,
                UserId = UserId
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        
        }

    }
}
