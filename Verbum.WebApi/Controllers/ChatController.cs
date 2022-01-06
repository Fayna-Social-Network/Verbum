using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Hubs;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.WebApi.Models;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IHubContext<VerbumHub> _hubContext;

        public ChatController(IVerbumDbContext dbContext, IHubContext<VerbumHub> hubContext) =>
            (_dbContext, _hubContext) = (dbContext, hubContext);

        [HttpPost("/sendmessage")]
        public async Task<ActionResult> SendMessage(Messages message)
        {
            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            var recipient = await _dbContext.Users.SingleAsync(r => r.Id == message.UserId);
           

            return Ok();
        }

        [HttpGet("/users")]
        public async Task<ActionResult<List<VerbumUser>>> GetAllUsers() {
            return await _dbContext.Users.ToListAsync();
        }

        [HttpPost("/getmessage")]
        public async Task<ActionResult<List<Messages>>> GetCorrespondence(GetCorrespondenceDto corr)
        {
            var toMe = await _dbContext.Messages
                 .Where(m => m.UserId == corr.Owner && m.Seller == corr.WithWho)
                 .ToListAsync();
            var toYou = await _dbContext.Messages
                .Where(m => m.UserId == corr.WithWho && m.Seller == corr.Owner)
                .ToListAsync();

            var correspondence = toMe.Concat(toYou).OrderBy(m => m.Timestamp).ToList();



            return correspondence;
        }

        [HttpPost("/addcontact")]
        public async Task<ActionResult> CreateUserContact(UserContact dto) {
            await _dbContext.UserContacts.AddAsync(dto);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            
            return Ok();
        }

        [HttpGet("/getcontacts/{userId}")]
        public async Task<ActionResult<List<UserContact>>> GetUserContacts(Guid userId)
        {
            var result = await _dbContext.UserContacts.Where(u => u.UserId == userId)
                .Include(p => p.User).ToListAsync();
            return Ok(result);

        }

        [HttpDelete("/deletecontacts/{Id}")]
        public async Task<ActionResult> DeleteUserContacts(Guid Id)
        {
            var item = await _dbContext.UserContacts.FindAsync(Id);
            if (item != null)
            {
                    _dbContext.UserContacts.Remove(item);
                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }
            return Ok();
        }





        [HttpPost("/addtoblack")]
        public async Task<ActionResult> AddUserToBlackList(UserBlackList dto)
        {
            await _dbContext.UserBlackLists.AddAsync(dto);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return Ok();
        }

        [HttpGet("/getblackusers/{userId}")]
        public async Task<ActionResult<List<UserContact>>> GetBlackUsers(Guid userId)
        {
            var blackUserList = await _dbContext.UserBlackLists.Where(c => c.UserId == userId).ToArrayAsync();
            return Ok(blackUserList);
        }

        [HttpDelete("/deleteblackuser/{Id}")]
        public async Task<ActionResult> DeleteBlackUser(Guid Id)
        {
            var item = await _dbContext.UserBlackLists.FindAsync(Id);
            if (item != null)
            {
                _dbContext.UserBlackLists.Remove(item);
                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }
            return Ok();
        }


    }
}
