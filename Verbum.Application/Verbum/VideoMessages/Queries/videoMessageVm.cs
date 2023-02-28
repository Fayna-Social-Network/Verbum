using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.ChatOnes;
using Verbum.Domain.UserFilesTable;

namespace Verbum.Application.Verbum.VideoMessages.Queries
{
    public class videoMessageVm :IMapWith<ChatVideoMessage>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<UserFile>? videoFiles { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<ChatVideoMessage, videoMessageVm>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(m => m.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(m => m.videoFiles, opt => opt.MapFrom(x => x.userFiles));

        }
    }
}