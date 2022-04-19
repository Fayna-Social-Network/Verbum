using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.Stikers;

namespace Verbum.Application.Verbum.StickerData.Queries.GetStickersByStickerGroup
{
    public class StickersLookupDto: IMapWith<Sticker>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Path { get; set; } = String.Empty;
        public Guid GroupId { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<Sticker, StickersLookupDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(m => m.Path, opt => opt.MapFrom(c => c.Path))
                .ForMember(m => m.GroupId, opt => opt.MapFrom(c => c.StickerGroupId));
        }
    }
}