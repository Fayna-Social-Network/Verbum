using Microsoft.EntityFrameworkCore;
using Verbum.Domain;
using Verbum.Domain.MessagesDb;
using Verbum.Domain.Stikers;
using Verbum.Domain.Users;
using Verbum.Domain.Users.Details;

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
        DbSet<Hobby> hobbies { get; set; }
        DbSet<PhoneNumber> phoneNumbers { get; set; }
        DbSet<SocialNetwork> socialNetworks { get; set; }
        DbSet<UserAdress> userAdresses { get; set; }
        DbSet<UserDetails> userDetails { get; set; }
        DbSet<ContactGroup> contactGroups { get; set; }
        DbSet<Sticker> Stickers { get; set; }
        DbSet<StickersGroup> stickersGroups { get; set; }   

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
