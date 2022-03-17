using Verbum.Application.Common.Mappings;
using Verbum.Domain.MessagesDb;
using AutoMapper;

namespace Verbum.Application.Verbum.ImageMessages.Queries.GetMessageImages
{
    public class MessageImagesVm : IMapWith<ImageAlbum>
    {
        public string? Header { get; set; }
        public string? Description { get; set; }
        public List<ImageMessageLookupDto>? Images { get; set;}

        public void Mapping(Profile profile) {
            profile.CreateMap<MessageImagesVm, ImageAlbum>()
                .ForMember(x => x.Header, opt => opt.MapFrom(a => a.Header))
                .ForMember(x => x.Description, opt => opt.MapFrom(a => a.Description));
                
        }
    }
}