using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Hubs;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.Message.Commands.CreateMessage
{
    public class SendMessageCommandHandler :IRequestHandler<SendMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly VerbumHubRepository _verbumHubRepository;
        private readonly CommonRepository _commonRepository;

        public SendMessageCommandHandler(IVerbumDbContext dbContext, VerbumHubRepository hubContext,
             CommonRepository commonRepository) =>
            (_dbContext, _verbumHubRepository, _commonRepository) = (dbContext, hubContext, commonRepository);

        public async Task<Guid> Handle(SendMessageCommand request, CancellationToken
            cancellationToken)
        {
            await _commonRepository.IsUserInBlackList(request.UserId, request.Seller);

            var message = new Messages
            {
                Id = request.Id,
                Text = request.Text,
                Seller = request.Seller,
                IsRead = false,
                Timestamp = DateTime.UtcNow,
                UserId = request.UserId
            };


            await _verbumHubRepository.NotificateUserForMessage(message);

            await _dbContext.Messages.AddAsync(message, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);


            return message.Id;
        }
    }
}
