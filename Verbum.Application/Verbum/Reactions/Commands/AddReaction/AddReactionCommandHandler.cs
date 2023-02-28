using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.ChatOnes;

#nullable disable
namespace Verbum.Application.Verbum.Reactions.Commands.AddReaction
{
    public class AddReactionCommandHandler :IRequestHandler<AddReactionCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public AddReactionCommandHandler(IVerbumDbContext verbumDbContext) => _dbContext = verbumDbContext;

        public async Task<Unit> Handle(AddReactionCommand request, CancellationToken cancellationToken) {
            var message = await _dbContext.chatMessages.Include(m => m.chatMessageReactions).FirstOrDefaultAsync(m => m.Id == request.MessageId);
            
            if (message == null) { 
                throw new NotFoundException(nameof(ChatMessage), request.MessageId);
            }

            var reaction = new ChatMessageReaction
            {
                ChatMessageId = request.MessageId,
                ReactionName = request.ReactionName,
                ReactionCount = 1,
                UserId = request.UserId
            };

            if (message.chatMessageReactions?.Count == 0)
            {
                await _dbContext.chatMessageReactions.AddAsync(reaction, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else {
                bool add = false;

                foreach (var r in message.chatMessageReactions) {
                    if (r.UserId == request.UserId) {
                        throw new IsAlreadyExistsException("This user has already left a reaction");
                    }

                    if (r.ReactionName == request.ReactionName) {
                       var query =  await _dbContext.chatMessageReactions.FirstOrDefaultAsync(n => n.Id == r.Id, cancellationToken);

                        if (query != null) {
                            query.ReactionCount = query.ReactionCount + 1;
                            await _dbContext.SaveChangesAsync(cancellationToken);
                            add = true;
                        }
                    }
                }

                if (!add) {
                    await _dbContext.chatMessageReactions.AddAsync(reaction, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

            }

            return Unit.Value;
        }
    }
}
