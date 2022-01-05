using Microsoft.EntityFrameworkCore;
using Verbum.Domain;

namespace Verbum.Application.Interfaces
{
    public interface IVerbumDbContext
    {
        DbSet<Message> Messages { get; set; }
        DbSet<VerbumUser> Users { get; set; }
        DbSet<UserContact> UserContacts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
