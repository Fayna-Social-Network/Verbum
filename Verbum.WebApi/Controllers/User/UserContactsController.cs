using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.UserContacts.Commands.AddContactToUser;
using Verbum.Application.Verbum.UserContacts.Commands.ChangeContactGroup;
using Verbum.Application.Verbum.UserContacts.Commands.DeleteContactFromUser;
using Verbum.Application.Verbum.UserContacts.Queries.GetUserContacts;
using Verbum.WebApi.Models.UserContacts;

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


        [Authorize]
        [HttpDelete("{contactId}")]
        public async Task<ActionResult> DeleteContactFromUser(Guid contactId) {

            var command = new DeleteContactFromUserCommand
            {
                contactId = contactId
            };
         
            await Mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateContactGroup (UpdateContactDto dto)
        {
            var command = _mapper.Map<ChangeContactGroupCommand>(dto);

            await Mediator.Send(command);

            return Ok();
        }


    }
}
