using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.UserGrops.UserGroup.Commands.AddUserToGroup;
using Verbum.Application.UserGrops.UserGroup.Commands.CreateUserGroup;
using Verbum.Application.UserGrops.UserGroup.Commands.DeleteUserGroup;
using Verbum.Application.UserGrops.UserGroup.Commands.OwnerAddUserToGroup;
using Verbum.Application.UserGrops.UserGroup.Commands.UpdateUserGroup;
using Verbum.Application.UserGrops.UserGroup.Queries.GetAllGroups;
using Verbum.Application.UserGrops.UserGroup.Queries.GetGroupById;
using Verbum.Application.UserGrops.UserGroup.Queries.GetUserGroups;
using Verbum.Application.UserGrops.UserGroup.Queries.SearchGroupsByName;
using Verbum.WebApi.Models.GroupsDtos;

namespace Verbum.WebApi.Controllers.GroupsControllers
{
    [Route("api/[controller]")]
    [ApiVersionNeutral]
    [ApiController]
    public class GroupsController : BaseController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateUserGroup(CreateGroupDto dto) 
        {
            var command = new CreateUserGroupCommand
            {
                GroupName = dto.GroupName,
                GroupAvatarPath = dto.GroupAvatarPath,
                GroupTheme = dto.GroupTheme,
                isClosedGroup = dto.isClosedGroup,
                UserId = UserId
            };

            var r = await Mediator.Send(command);

            return Ok(r);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateUserGroup(UpdateGroupDto dto) 
        {
            var command = new UpdateUserGroupCommand
            {
                GroupId = dto.GroupId,
                UserId = UserId,
                GroupAvatarPath = dto.GroupAvatarPath,
                NewGroupName = dto.NewGroupName,
                isClosed = dto.isClosed
            };

            await Mediator.Send(command);

            return Ok();
            
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteUserGroup(Guid id) 
        {
            var command = new DeleteUserGroupCommand
            {
                GroupId = id,
                UserId = UserId
            };

            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost("add_user")]
        [Authorize]
        public async Task<ActionResult> AddUserToGroup(AddUserToGroupCommand addUser) 
        {
            await Mediator.Send(addUser);

            return Ok();
        }

        [HttpPost("owner_add_user")]
        [Authorize]
        public async Task<ActionResult> OwnerAddUserToGroup(OwnerAddUserToGroupDto dto) 
        {
            var command = new OwnerAddUserToGroupCommand
            {
                GroupId = dto.GroupId,
                UserId = dto.UserId,
                OwnerGroupId = UserId
            };

            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<GetAllGroupsVm>> GetAllUserGroups() 
        {
            var query = new GetAllGroupsQuery { };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("group/{id}")]
        [Authorize]
        public async Task<ActionResult<GetGroupByIdVm>> GetUserGroupById(Guid id) 
        {
            var query = new GetGroupByIdQuery 
            {
                GroupId = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("user_groups/{userId}")]
        [Authorize]
        public async Task<ActionResult<GetAllGroupsVm>> GetOwnerUserGroups(Guid userId) 
        {
            var query = new GetUserGroupsQuery { UserId = userId };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("search/{name}")]
        [Authorize]
        public async Task<ActionResult<GetAllGroupsVm>> SearchUserGroupsByName(string name) 
        {
            var query = new SearchGroupsByNameQuery { GroupName = name };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

    }
}
