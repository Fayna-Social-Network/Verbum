using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.VideoMessages.Commands.CreateVideoMessage;
using Verbum.Application.Verbum.VideoMessages.Queries;
using Verbum.WebApi.Models.Messages;

namespace Verbum.WebApi.Controllers.Message
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class VideoMessageController : BaseController
    {
      
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateVideoMessage(CreateVideoMessageDto createVideo) {

            var command = new CreateVideoMessageCommand
            {
                VideoPath = createVideo.VideoPath,
                Title = createVideo.Title,
                ContactId = createVideo.ContactId,
                UserId = UserId
            };

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpGet ("{id}")]
        [Authorize]
        public async Task<ActionResult<videoMessageVm>> GetVideoMessage(Guid id) {
            
            var query = new GetVideoMessageQuery
            {
                MessageId = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
