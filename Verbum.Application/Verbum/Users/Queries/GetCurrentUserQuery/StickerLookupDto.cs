using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.Stikers;

namespace Verbum.Application.Verbum.Users.Queries.GetCurrentUserQuery
{
    public class StickerLookupDto :IMapWith<Sticker>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Path { get; set; } = String.Empty;

        public void Mapping(Profile profile) {
            profile.CreateMap<Sticker, StickerLookupDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(a => a.Name))
                .ForMember(x => x.Path, opt => opt.MapFrom(a => a.Path));
        }
    }
}