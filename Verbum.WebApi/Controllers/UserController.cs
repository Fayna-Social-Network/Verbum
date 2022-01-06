using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.Users.Queries;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        
        [HttpGet]
        public async Task<ActionResult<UsersListVm>> GetAllUsers() {
            var query = new GetAllUsersQuery
            { };
                
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

    }
}
