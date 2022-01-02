using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Commands.UpdateMessage
{
    public class UpdateMessageCommandHandler :IRequestHandler<UpdateMessageCommand>
    {
        private readonly IVerbumDbContext _context;

        public UpdateMessageCommandHandler(IVerbumDbContext context) =>
            _context = context;

        public async Task<Unit> Handle(UpdateMessageCommand request, CancellationToken cancellationToken) {
            var entity =
                await _context.Messages.FirstOrDefaultAsync(mess =>
                    mess.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Message), request.Id);
            }

            entity.Text = request.Text;
            entity.Timestamp = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;


        }
    }
}
