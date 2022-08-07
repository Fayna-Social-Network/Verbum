using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.UserFilesAndMessages.Commands.CreateFileMessage;
using Verbum.Application.Verbum.UserFilesAndMessages.Queries.GetFileMessageQuery;
using Verbum.WebApi.Models.Messages;

namespace Verbum.WebApi.Controllers.Message
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class FileMessageController : BaseController
    {

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateFileMessage(CreateFileMessageDto dto) {

            var command = new CreateFileMessageCommand
            {
                Path = dto.Path,
                Type = dto.Type,
                Seller = UserId,
                UserId = dto.UserId
            };

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpGet("{messageId}")]
        [Authorize]
        public async Task<ActionResult<FileMessageVm>> GetFileMessage(Guid messageId) {
            
            var query = new GetFileMessageQuery
            {
                MessageId = messageId
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        
        }

    }
}
