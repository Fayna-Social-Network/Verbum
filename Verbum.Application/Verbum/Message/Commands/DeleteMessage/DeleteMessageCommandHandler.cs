using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.Commands.DeleteMessage
{
    public class DeleteMessageCommandHandler :IRequestHandler<DeleteMessageCommand>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly FilesRepository _filesRepository;
        private readonly VerbumHubRepository _verbumHub;

        public DeleteMessageCommandHandler(IVerbumDbContext dbContext, FilesRepository filesRepository, VerbumHubRepository verbumHub) =>
            (_dbContext, _filesRepository, _verbumHub) = (dbContext, filesRepository, verbumHub);

        public async Task<Unit> Handle(DeleteMessageCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Messages
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || request.UserId != entity.UserId && request.UserId != entity.Seller) {
                throw new NotFoundException(nameof(Messages), request.Id);
            }

            await DeletingFilesIncludedMessage(entity.Id);
            await _verbumHub.NotificateUserForMessageIsDelete(entity, request.UserId);

            _dbContext.Messages.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task DeletingFilesIncludedMessage(Guid messageId) {
            
                var audio = await _dbContext.audioMessages.SingleOrDefaultAsync(a => a.MessageId == messageId);
                if (audio != null)
                {
                var audios = await _dbContext.audioMessages.Where(a => a.path == audio.path).ToListAsync();
                    if (audios.Count == 1)
                    {
                        _filesRepository.Delete(audio.path!);
                    }
                }
            var imageAlbum = await _dbContext.ImageAlbums.Include(im => im.ImageMessages).SingleOrDefaultAsync(a => a.MessageId == messageId);
            if (imageAlbum != null)
            {
                if (imageAlbum.ImageMessages != null)
                {
                    foreach (var image in imageAlbum.ImageMessages) {
                        var images = await _dbContext.Images.Where(im => im.Path == image.Path).ToListAsync();
                        if (images.Count == 1)
                        {
                            _filesRepository.Delete(image.Path!);
                        }
                    }
                }
            }

            var video = await _dbContext.videoMessages.SingleOrDefaultAsync(a => a.MessageId == messageId);
            if (video != null)
            {
                var videos = await _dbContext.videoMessages.Where(a => a.Path == video.Path).ToListAsync();
                if (videos.Count == 1)
                {
                    _filesRepository.Delete(video.Path!);
                }
            }

        }
        
    }
}
