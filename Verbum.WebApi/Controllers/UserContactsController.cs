using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.UserContacts.Commands.AddContactToUser;
using Verbum.Application.Verbum.UserContacts.Queries.GetUserContacts;
using Verbum.WebApi.Models;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]

    [Route("api/[controller]")]
    [ApiController]
    public class UserContactsController : BaseController
    {
        private readonly IMapper _mapper;

        public UserContactsController(IMapper mapper) => _mapper = mapper;
       
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddContactToUser(AddContactDto dto) {
            var command = _mapper.Map<AddContactToUserCommand>(dto);

            var messId = await Mediator.Send(command);
            return Ok(messId);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserContactsVm>> GetUserContacts(Guid id) {
            var query = new GetUserContactsQuery
            {
                UserId = id,
                
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
