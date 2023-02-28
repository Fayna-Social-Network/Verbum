using Verbum.Application.Common.Mappings;
using AutoMapper;
using Verbum.Domain.ChatOnes;
using Verbum.Domain.UserFilesTable;

namespace Verbum.Application.Verbum.AudioMessages.Queries.GetAudioMessageQuery
{
    public class AudioMessageVm :IMapWith<ChatAudioMessage>
    {
        public Guid Id { get; set; }
        public UserFile? PreviewImagePath { get; set; }
        public List<UserFile>? audioFilePaths { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<ChatAudioMessage, AudioMessageVm>()
                .ForMember(a => a.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(a => a.audioFilePaths, opt => opt.MapFrom(o => o.userFiles));
        }
    }
}