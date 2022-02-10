using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.ImageMessages.Commands.AddImagesMessageCommand;
using Verbum.Application.Verbum.ImageMessages.Queries.GetMessageImages;
using Verbum.WebApi.Models.Messages;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesMessageController : BaseController
    {

        private readonly IMapper _mapper;

        public ImagesMessageController(IMapper mapper) => _mapper = mapper;

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> SendImages(AddImageMessageDto dto) {
            var command = _mapper.Map<AddImagesMessageCommand>(dto);

            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpGet("{messageId}")]
        [Authorize]
        public async Task<ActionResult<MessageImagesDto>> GetMessageImages(Guid messageId) {
            var query = new GetMessageImagesQuery
            {
                MessageId = messageId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

    }
}
