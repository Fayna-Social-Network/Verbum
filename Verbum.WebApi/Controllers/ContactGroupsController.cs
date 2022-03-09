using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.ContactGroups.Commands.CreateContactGroup;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactGroupsController : BaseController
    {
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
    }
}
