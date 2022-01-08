using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.Users.Queries.GetAllUserQuery;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UsersListVm>> GetAllUsers() {
            var query = new GetAllUsersQuery
            { };
                
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

    }
}
