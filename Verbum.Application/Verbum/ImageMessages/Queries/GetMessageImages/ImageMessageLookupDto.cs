using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.ImageMessages.Queries.GetMessageImages
{
    public class ImageMessageLookupDto :IMapWith<ImageMessage>
    {
        public Guid id { get; set; }
        public string? Path { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<ImageMessageLookupDto, ImageMessage>()
                .ForMember(i => i.id, opt => opt.MapFrom(im => im.id))
                .ForMember(i => i.Path, opt => opt.MapFrom(im => im.Path));
        } 
    }
}
