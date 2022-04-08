using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.VideoMessages.Queries
{
    public class videoMessageVm :IMapWith<VideoMessage>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public Guid MessageId { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<VideoMessage, videoMessageVm>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(m => m.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(m => m.Path, opt => opt.MapFrom(x => x.Path))
                .ForMember(m => m.MessageId, opt => opt.MapFrom(x => x.MessageId));

        }
    }
}