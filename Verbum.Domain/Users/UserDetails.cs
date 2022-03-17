
using Verbum.Domain.Users.Details;

namespace Verbum.Domain.Users
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string? Profession { get; set; }
        public string? Tagline { get; set; } 
        public string? About { get; set; }
       
        public Guid UserId { get; set; }
        public VerbumUser? User { get; set; }

        public ICollection<Hobby>? Hobbies { get; set; }
        public ICollection<PhoneNumber>? phoneNumbers { get; set; }
        public ICollection<SocialNetwork>? socialNetworks { get; set; }
        public UserAdress? Adress { get; set; }
    }
}
