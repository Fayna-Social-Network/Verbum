using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IVerbumDbContext _dbContext;

        public ChatController(IVerbumDbContext dbContext) =>
            _dbContext = dbContext;

        [HttpPost("/sendmessage")]
        public async Task<ActionResult> Create(Message message)
        {
            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return Ok();
        }

    }
}
