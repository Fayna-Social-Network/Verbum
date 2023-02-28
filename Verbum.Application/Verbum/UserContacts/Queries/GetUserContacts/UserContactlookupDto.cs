using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain;
using Verbum.Domain.ChatOnes;


#nullable disable

namespace Verbum.Application.Verbum.UserContacts.Queries.GetUserContacts
{
    public class UserContactlookupDto :IMapWith<UserContact>
    {
        public Guid ContactId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Guid GroupId { get; set; }
        public Guid ChatId { get; set; }
        public bool IsMutted { get; set; }
        public bool Favorite { get; set; }
        public string ContactBackGroundImage { get; set; } 
        public string GroupName { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public bool IsOnline { get; set; }
        public string HubConnectionId { get; set; }
        public DateTime UserRegistrationDate { get; set; }
        public Chat chat { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserContact, UserContactlookupDto>()
                .ForMember(u => u.ContactId, opt => opt.MapFrom(m => m.Id))
                .ForMember(u => u.UserId, opt => opt.MapFrom(m => m.User.Id))
                .ForMember(u => u.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(u => u.GroupId, opt => opt.MapFrom(m => m.Group.Id))
                .ForMember(u => u.ChatId, opt => opt.MapFrom(m => m.ChatId))
                .ForMember(u => u.IsMutted, opt => opt.MapFrom(m => m.IsMuted))
                .ForMember(u => u.Favorite, opt => opt.MapFrom(m => m.Favorites))
                .ForMember(u => u.ContactBackGroundImage, opt => opt.MapFrom(m => m.ContactBackGroundImage))
                .ForMember(u => u.GroupName, opt => opt.MapFrom(m => m.Group.GroupName))
                .ForMember(u => u.NickName, opt => opt.MapFrom(m => m.User.NickName))
                .ForMember(u => u.FirstName, opt => opt.MapFrom(m => m.User.FirstName))
                .ForMember(u => u.LastName, opt => opt.MapFrom(m => m.User.LastName))
                .ForMember(u => u.Avatar, opt => opt.MapFrom(m => m.User.Avatar))
                .ForMember(u => u.Email, opt => opt.MapFrom(m => m.User.Email))
                .ForMember(u => u.IsOnline, opt => opt.MapFrom(m => m.User.IsOnline))
                .ForMember(u => u.HubConnectionId, opt => opt.MapFrom(m => m.User.HubConnectionId))
                .ForMember(u => u.UserRegistrationDate, opt => opt.MapFrom(m => m.User.UserRegistrationDate))
                .ForMember(u => u.chat, opt => opt.MapFrom(m => m.userChat));

        }
    }
}