using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.WebApi.Hubs;
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
        public async Task<ActionResult> SendMessage(Message message)
        {
            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            var recipient = await _dbContext.Users.SingleAsync(r => r.Id == message.UserId);
            if (recipient != null)
            {
                if (recipient.IsOnline)
                {
                   
                    var clientMessage = new SendClientMessage
                    {
                        Text = message.Text,
                        Seller = message.Seller,
                        isRead = false,
                        Timestamp = message.Timestamp,
                        UserId = message.UserId
                    };
                    if (recipient.HubConnectionId != null)
                    {
                       await _hubContext.Clients.Client(recipient.HubConnectionId).SendAsync("acceptMessage", clientMessage);
                    }
                }
            }

            return Ok();
        }

        [HttpGet("/users")]
        public async Task<ActionResult<List<VerbumUser>>> GetAllUsers() {
            return await _dbContext.Users.ToListAsync();
        }

        [HttpPost("/getmessage")]
        public async Task<ActionResult<List<Message>>> GetCorrespondence(GetCorrespondenceDto corr)
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

    }
}
