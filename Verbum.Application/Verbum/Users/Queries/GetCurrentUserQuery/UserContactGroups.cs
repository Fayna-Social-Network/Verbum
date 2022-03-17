using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.Users;

namespace Verbum.Application.Verbum.Users.Queries.GetCurrentUserQuery
{
    public class UserContactGroups : IMapWith<ContactGroup>
    {
        public Guid Id { get; set; }
        public string? GroupName { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<ContactGroup, UserContactGroups>()
                .ForMember(g => g.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(g => g.GroupName, opt => opt.MapFrom(a => a.GroupName));
        }
    }
}