using Verbum.Application.Common.Mappings;
using AutoMapper;
using Verbum.Domain.ChatOnes;
using Verbum.Domain.UserFilesTable;

namespace Verbum.Application.Verbum.ImageMessages.Queries.GetMessageImages
{
    public class MessageImagesVm : IMapWith<ChatImageMessage>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<UserFile>? ImagePaths { get; set;}

        public void Mapping(Profile profile) {
            profile.CreateMap<ChatImageMessage, MessageImagesVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(a => a.Title))
                .ForMember(x => x.Description, opt => opt.MapFrom(a => a.Description))
                .ForMember(x => x.ImagePaths, opt => opt.MapFrom(a => a.userFiles));
                
        }
    }
}