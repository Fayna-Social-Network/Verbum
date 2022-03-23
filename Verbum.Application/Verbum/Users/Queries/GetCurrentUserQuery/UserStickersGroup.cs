using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.Stikers;

namespace Verbum.Application.Verbum.Users.Queries.GetCurrentUserQuery
{
    public class UserStickersGroup :IMapWith<StickersGroup>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<StickerLookupDto>? stickers { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<StickersGroup, UserStickersGroup>()
                .ForMember(c => c.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(c => c.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(c => c.stickers, opt => opt.MapFrom(x => x.Stickers));
        }
    }
}
