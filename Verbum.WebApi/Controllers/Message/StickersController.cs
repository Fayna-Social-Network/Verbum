using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.StickerData.Commands.AddStickerGroupToUser;
using Verbum.Application.Verbum.StickerData.Commands.DeleteStickersGroupFromUser;
using Verbum.Application.Verbum.StickerData.Queries.GetAllStickersGroups;
using Verbum.Application.Verbum.StickerData.Queries.GetStickerById;
using Verbum.Application.Verbum.StickerData.Queries.GetStickersByStickerGroup;

namespace Verbum.WebApi.Controllers.Message
{
    [Route("api/[controller]")]
    [ApiVersionNeutral]
    [ApiController]
    public class StickersController : BaseController
    {
        [Authorize]
        [HttpPost("addStickerGroupToUser/{groupId}")]
        public async Task<ActionResult> AddStickerGroupToUser(Guid groupId) {
            var command = new AddStickerGroupToUserCommand
            {
                StickerGroupId = groupId,
                UserId = UserId
            };

            await Mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetAllGroups")]
        public async Task<ActionResult<StickerGroupsVm>> GetAllStickersGroups() {
            var query = new GetAllStickerGroupsQuery { };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [Authorize]
        [HttpGet("GetStickersByGroup/{groupId}")]
        public async Task<ActionResult<StikersVm>> GetStickersByGroup(Guid groupId) {
            var query = new GetStickerByStickerGroupQuery
            {
                StickersGroupId = groupId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [Authorize]
        [HttpDelete("DeleteStickerGroupFromUser/{groupId}")]
        public async Task<ActionResult> DeleteStickerGroupFromUser(Guid groupId) {
            var command = new DeleteStickersGroupFromUserCommand
            {
                StickerGroupId = groupId,
                UserId = UserId
            };

            await Mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetStickerById/{id}")]
        public async Task<ActionResult<StickerDto>> GetStickerById(Guid id) {
            var query = new GetStickerByIdQuery
            {
                stickerId = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


    }
}
