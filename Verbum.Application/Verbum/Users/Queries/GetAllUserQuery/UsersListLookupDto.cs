using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Users.Queries.GetAllUserQuery
{
    public class UsersListLookupDto :IMapWith<VerbumUser>
    {
        public Guid Id { get; set; }
        public string? NickName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public bool IsOnline { get; set; }
        public string? HubConnectionId { get; set; }
        public DateTime UserRegistrationDate { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<VerbumUser, UsersListLookupDto>()
                .ForMember(u => u.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(u => u.NickName, opt => opt.MapFrom(m => m.NickName))
                .ForMember(u => u.FirstName, opt => opt.MapFrom(m => m.FirstName))
                .ForMember(u => u.LastName, opt => opt.MapFrom(m => m.LastName))
                .ForMember(u => u.Avatar, opt => opt.MapFrom(m => m.Avatar))
                .ForMember(u => u.Email, opt => opt.MapFrom(m => m.Email))
                .ForMember(u => u.IsOnline, opt => opt.MapFrom(m => m.IsOnline))
                .ForMember(u => u.HubConnectionId, opt => opt.MapFrom(m => m.HubConnectionId))
                .ForMember(u => u.UserRegistrationDate, opt => opt.MapFrom(m => m.UserRegistrationDate));

        }


    }
}