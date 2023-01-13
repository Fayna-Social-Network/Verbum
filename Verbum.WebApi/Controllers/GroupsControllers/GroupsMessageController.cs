using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.UserGrops.GroupMessage.Commands.CreateGroupMessage;
using Verbum.Application.UserGrops.GroupMessage.Queries.GetGroupMessagesByTheme;
using Verbum.WebApi.Models.GroupsMessageDtos;

namespace Verbum.WebApi.Controllers.GroupsControllers
{
    [Route("api/[controller]")]
    [ApiVersionNeutral]
    [ApiController]
    public class GroupsMessageController : BaseController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateGroupMessage(CreateGroupMessageDto dto)
        {
            var command = new CreateGroupMessageCommand
            {
                SellerId = UserId,
                GroupId = dto.GroupId,
                GroupThemeId = dto.GroupThemeId,
                Text = dto.Text
            };

            var r = await Mediator.Send(command);

            return Ok(r);
        }

        [HttpGet("{groupId}/{themeId}")]
        [Authorize]
        public async Task<ActionResult<GetGroupMessagesVm>> GetGroupMessagesByTheme(Guid groupId, Guid themeId) 
        {
            var query = new GetGroupMessagesByThemeQuery
            {
                GroupId = groupId,
                GroupThemeId = themeId,
                UserId = UserId
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
