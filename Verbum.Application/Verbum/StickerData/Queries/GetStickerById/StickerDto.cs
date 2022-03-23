using Verbum.Application.Common.Mappings;
using Verbum.Domain.Stikers;
using AutoMapper;

namespace Verbum.Application.Verbum.StickerData.Queries.GetStickerById
{
    public class StickerDto :IMapWith<Sticker> 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Path { get; set; } = String.Empty;

        public void Mapping(Profile profile) {
            profile.CreateMap<Sticker, StickerDto>()
                .ForMember(s => s.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(s => s.Name, opt => opt.MapFrom(a => a.Name))
                .ForMember(s => s.Path, opt => opt.MapFrom(a => a.Path));
        }
    }
}