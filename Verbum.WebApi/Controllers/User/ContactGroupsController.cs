using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.ContactGroups.Commands.CreateContactGroup;
using Verbum.Application.Verbum.ContactGroups.Commands.DeleteContactGroup;
using Verbum.Application.Verbum.ContactGroups.Commands.UpdateContactGroup;
using Verbum.Application.Verbum.ContactGroups.Queries.GetIdMainGroup;
using Verbum.WebApi.Models.contactGroup;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactGroupsController : BaseController
    {

        private readonly IMapper _mapper;

        public ContactGroupsController(IMapper mapper) => _mapper = mapper;

        [HttpPost("{name}")]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateContactGroup(string name) {

            var command = new CreateContactGroupCommand
            {
                GroupName = name,
                UserId = UserId
            };

            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteContactGroup(Guid id) {
            var command = new DeleteContactGroupCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet("GetIdGeneralGroup")]
        [Authorize]
        public async Task<ActionResult<Guid>> GetIdGeneralGroup() {
            var query = new GetIdMainGroupQuery { };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateContactGroupName(UpdateContactGroupDto Dto) {
            var command = _mapper.Map<UpdateContactGroupCommand>(Dto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
