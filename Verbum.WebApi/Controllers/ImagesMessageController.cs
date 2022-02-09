using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.ImageMessages.Commands.AddImagesMessageCommand;
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
        public async Task<ActionResult> SendImages(AddImageMessageDto dto) {
            var command = _mapper.Map<AddImagesMessageCommand>(dto);

            var vm = await Mediator.Send(command);
            return Ok(vm);
        } 
    }
}
