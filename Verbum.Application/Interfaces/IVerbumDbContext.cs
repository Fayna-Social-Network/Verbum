using Microsoft.EntityFrameworkCore;
using Verbum.Domain;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Interfaces
{
    public interface IVerbumDbContext
    {
        DbSet<Messages> Messages { get; set; }
        DbSet<VerbumUser> Users { get; set; }
        DbSet<UserContact> UserContacts { get; set; }
        DbSet<UserBlackList> UserBlackLists { get; set; }
        DbSet<MessageReaction> MessageReactions { get; set; }
        DbSet<ImageAlbum> ImageAlbums { get; set; }
        DbSet<ImageMessage> Images { get; set; }
        DbSet<AudioMessage> audioMessages { get; set; }
        DbSet<VideoMessage> videoMessages { get; set; }
        DbSet<FileMessage> fileMessages { get; set; }
        

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
