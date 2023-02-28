using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.AudioMessages.Commands.AddAudioMessage;
using Verbum.Application.Verbum.AudioMessages.Queries.GetAudioMessageQuery;
using Verbum.WebApi.Models.Messages;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class AudioMessageController : BaseController
    {

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateAudioMessage(AddAudioMessageDto dto) {
            var command = new AddAudioMessageCommand
            {
                audioFiles = dto.audioFiles,
                SellerId = UserId,
                UserId = dto.UserId
            };

           var vw = await Mediator.Send(command);
           return Ok(vw);
        }


        [HttpGet("{messageId}")]
        [Authorize]
        public async Task<ActionResult<AudioMessageVm>> GetAudioMessage(Guid messageId) {
            var query = new GetAudioMessageQuery
            {
                MessageId = messageId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

    }
}
