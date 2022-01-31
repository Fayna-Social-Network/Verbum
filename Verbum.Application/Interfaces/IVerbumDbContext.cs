using Microsoft.EntityFrameworkCore;
using Verbum.Domain;

namespace Verbum.Application.Interfaces
{
    public interface IVerbumDbContext
    {
        DbSet<Messages> Messages { get; set; }
        DbSet<VerbumUser> Users { get; set; }
        DbSet<UserContact> UserContacts { get; set; }
        DbSet<UserBlackList> UserBlackLists { get; set; }
        DbSet<MessageReaction> MessageReactions { get; set; }
      //  DbSet<Image> Images { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
