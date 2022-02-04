using Verbum.Application.Common.Mappings;
using Verbum.Domain;
using AutoMapper;

namespace Verbum.Application.Verbum.AudioMessages.Queries.GetAudioMessageQuery
{
    public class AudioMessageVm :IMapWith<AudioMessage>
    {
        public Guid Id { get; set; }
        public string? Path { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<AudioMessage, AudioMessageVm>()
                .ForMember(a => a.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(a => a.Path, opt => opt.MapFrom(o => o.path));
        }
    }
}