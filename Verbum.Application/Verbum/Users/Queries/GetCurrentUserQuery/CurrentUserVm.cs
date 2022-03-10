using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Users.Queries.GetCurrentUserQuery
{
    public class CurrentUserVm :IMapWith<VerbumUser>
    {
        public Guid Id { get; set; }
        public string? NickName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public bool IsOnline { get; set; } = false;
        public string? HubConnectionId { get; set; }
        public DateTime UserRegistrationDate { get; set; }
        public List<UserContactGroups>? contactGroups { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<VerbumUser, CurrentUserVm>()
                .ForMember(u => u.Id, opt => opt.MapFrom(x => x.Id))
                 .ForMember(u => u.NickName, opt => opt.MapFrom(x => x.NickName))
                  .ForMember(u => u.FirstName, opt => opt.MapFrom(x => x.FirstName))
                   .ForMember(u => u.LastName, opt => opt.MapFrom(x => x.LastName))
                    .ForMember(u => u.Avatar, opt => opt.MapFrom(x => x.Avatar))
                     .ForMember(u => u.Email, opt => opt.MapFrom(x => x.Email))
                      .ForMember(u => u.IsOnline, opt => opt.MapFrom(x => x.IsOnline))
                       .ForMember(u => u.HubConnectionId, opt => opt.MapFrom(x => x.HubConnectionId))
                        .ForMember(u => u.UserRegistrationDate, opt => opt.MapFrom(x => x.UserRegistrationDate))
                         .ForMember(u => u.contactGroups, opt => opt.MapFrom(x => x.ContactGroups));    

        }
    }
}