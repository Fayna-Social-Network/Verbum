using Verbum.Domain.ChatOnes;
using Verbum.Domain.Users;

namespace Verbum.Domain
{
    public class UserContact
    {
        public Guid Id { get; set; }
        public Guid Contact { get; set; }
        public string? Name { get; set; }
        public string? ContactBackGroundImage { get; set; }
        public bool IsMuted { get; set; }
        public bool Favorites { get; set; }  

        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public Guid ChatId { get; set; }
        public virtual VerbumUser? User { get; set; } 
        public virtual ContactGroup? Group { get; set; }
        public virtual Chat? userChat { get; set; } 
    }
}