using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.Stikers;

namespace Verbum.Application.Verbum.StickerData.Queries.GetAllStickersGroups
{
    public class StickerGroupsLookupDto :IMapWith<StickersGroup>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<Sticker>? stickers { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<StickersGroup, StickerGroupsLookupDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(a => a.Name))
                .ForMember(x => x.stickers, opt => opt.MapFrom(a => a.Stickers));
        }
    }
}