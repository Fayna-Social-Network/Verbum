using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.Users.Commands.UpdateUserCommand;
using Verbum.Application.Verbum.Users.Queries.GetAllUserQuery;
using Verbum.Application.Verbum.Users.Queries.GetCurrentUserQuery;
using Verbum.Application.Verbum.Users.Queries.GetUsersByCountAndPage;
using Verbum.Application.Verbum.Users.Queries.SearchUsersByNickName;
using Verbum.WebApi.Models;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UsersListVm>> GetAllUsers() {
            var query = new GetAllUsersQuery
            { };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpGet("searchbyname/{text}")]
        [Authorize]
        public async Task<ActionResult<UsersListVm>> SearchUserByNickName(string text) {
            var query = new SearchUserByNickNameQuery
            {
                Text = text
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        } 

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserDto dto) {

            var command = _mapper.Map<UpdateUserCommand>(dto);

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{Nickname}")]
        [Authorize]
        public async Task<ActionResult<CurrentUserVm>> GetCurrentUser(string Nickname) {

            var query = new GetCurrentUserQuery
            {
           
                NickName = Nickname

            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpGet("{CountInPage}/{page}")]
        [Authorize]
        public async Task<ActionResult<UsersListVm>> GetUsersByCountAndPage(int CountInPage, int Page) {
            var query = new GetUsersByCountAndPageQuery
            {
                Page = Page,
                Count = CountInPage
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        } 


    }
}
