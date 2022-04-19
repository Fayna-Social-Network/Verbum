using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Users.Queries.GetCurrentUserQuery
{
    public class UserBlackListLoocup :IMapWith<UserBlackList>
    {
        public Guid Id { get; set; }
        public Guid BlockedUser { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<UserBlackList, UserBlackListLoocup>()
                .ForMember(b => b.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(b => b.BlockedUser, opt => opt.MapFrom(x => x.Contact));
        }
    }
}