using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.Commands.CreateMessage;
using Verbum.Application.Verbum.Commands.DeleteMessage;
using Verbum.Application.Verbum.Commands.UpdateMessage;
using Verbum.Application.Verbum.Queries.GetMessageList;
using Verbum.WebApi.Models;

namespace Verbum.WebApi.Controllers
{
    //[ApiVersion("1.0")]
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {
        private readonly IMapper _mapper;

        public MessageController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of Messages
        /// <remarks>
        /// Sample request:
        /// GET /message
        /// </remarks>
        /// </summary>
        /// <returns>Returns MessageListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageListVm>> GetAll() {
            var query = new GetMessageListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMessageDto createMessageDto) {
            var command = _mapper.Map<CreateMessageCommand>(createMessageDto);
            command.UserId = UserId;
            var messId = await Mediator.Send(command);
            return Ok(messId);
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id) {

            var command = new DeleteMessageCommand
            {
                Id = id,
                UserId = UserId
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(UpdateMessageDto updateMessage) {
            var command = _mapper.Map<UpdateMessageCommand>(updateMessage);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
