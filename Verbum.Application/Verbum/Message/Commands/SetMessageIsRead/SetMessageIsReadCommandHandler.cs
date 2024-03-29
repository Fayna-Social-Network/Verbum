﻿using MediatR;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.Message.Commands.SetMessageIsRead
{
    public class SetMessageIsReadCommandHandler :IRequestHandler<SetMessageIsReadCommand>
    {

        private readonly IVerbumDbContext _dbContext;
        private readonly VerbumHubRepository _verbumHubRepository;

        public SetMessageIsReadCommandHandler(IVerbumDbContext dbContext, VerbumHubRepository verbumHub) => 
            (_dbContext, _verbumHubRepository) = (dbContext, verbumHub);


        public async Task<Unit> Handle(SetMessageIsReadCommand request, CancellationToken cancellationToken) {
            
            var message = await _dbContext.Messages.FindAsync(new object[] { request.Id }, cancellationToken);

            if (message == null || message.UserId != request.UserId)
            {
               throw new NotFoundException(nameof(Messages), request.Id);
            }

            await _verbumHubRepository.NotificateUserForMessageIsRead(message);

            message.IsRead = true;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
