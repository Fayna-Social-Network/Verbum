using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.Message.Queries.GetMessageById
{
    public class GetMessageByIdQueryHandler :IRequestHandler<GetMessageByIdQuery, Messages>
    {
        private readonly IVerbumDbContext _dbContext;

        public GetMessageByIdQueryHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task<Messages> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken) {
            
            var query = await _dbContext.Messages.FirstOrDefaultAsync(m => m.Id == request.MessageId);

            if (query == null) {
                throw new NotFoundException(nameof(Messages), request.MessageId);
            }

            return query;
        } 
    }
}
