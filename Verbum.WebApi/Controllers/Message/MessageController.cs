﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.Commands.DeleteMessage;
using Verbum.Application.Verbum.Commands.UpdateMessage;
using Verbum.Application.Verbum.Message.Commands.CreateMessage;
using Verbum.Application.Verbum.Message.Commands.SetMessageIsRead;
using Verbum.Application.Verbum.Message.Queries.GetCorrespondence;
using Verbum.Application.Verbum.Message.Queries.GetCorrespondenceWithUnknowContact;
using Verbum.Application.Verbum.Message.Queries.GetMessageById;
using Verbum.Application.Verbum.Message.Queries.GetUnreadMessageCounter;
using Verbum.Domain.MessagesDb;
using Verbum.WebApi.Models;

namespace Verbum.WebApi.Controllers
{
    //[ApiVersion("1.0")]
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MessageController> _logger;

        public MessageController(IMapper mapper, ILogger<MessageController> logger) => 
            (_mapper, _logger) = (mapper, logger);

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
        [HttpPost("correspondence")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CorrespondenceVm>> GetCorrespondence([FromBody] GetCorrespondenceDto dto) {
            _logger.LogInformation("GetCorrespondences executing...");
            var query = new GetCorrespondenceQuery
            {
                Owner = dto.Owner,
                WithWho = dto.WithWho
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("correspondence/{userId}")]
        [Authorize]
        public async Task<ActionResult<CorrespondenceVm>> GetCorrespondenceWithUnknowContact(Guid userId) {
            var query = new GetCorrespondenceWithUnknowContactQuery
            {
                UserId = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("isRead/{id}")]
        [Authorize]
        public async Task<ActionResult> SetMesssageIsRead(Guid id) {
            var command = new SetMessageIsReadCommand
            {
                Id = id,
                UserId = UserId
            };
            var r = await Mediator.Send(command);
            return Ok(r);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> SendMessage([FromBody] SendMessageDto sendMessageDto) {
            var command = _mapper.Map<SendMessageCommand>(sendMessageDto);
          
            var messId = await Mediator.Send(command);
            return Ok(messId);
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {

            var command = new DeleteMessageCommand
            {
                Id = id,
                UserId = UserId
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Messages>> GetMessageById(Guid Id) {
            var query = new GetMessageByIdQuery
            {
                MessageId = Id
            };

            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getCountUnreadMessage/{contactId}")]
        [Authorize]
        public async Task<ActionResult<int>> GetUnreadMessageCount(Guid contactId) {
            
            var query = new GetUnreadMessageCounterQuery {
                
                ContactId = contactId,
                UserId = UserId
            
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
            
        }

        //[HttpPut]
        //[Authorize]
        //public async Task<ActionResult> Update(UpdateMessageDto updateMessage) {
        //    var command = _mapper.Map<UpdateMessageCommand>(updateMessage);
        //    command.UserId = UserId;
        //    await Mediator.Send(command);
        //    return NoContent();
        //}
    }
}
