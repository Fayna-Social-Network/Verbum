using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.ChatOnes;
using Verbum.Domain.UserFilesTable;

namespace Verbum.Application.Verbum.UserFilesAndMessages.Queries.GetFileMessageQuery
{
    public class FileMessageVm : IMapWith<ChatFileMessage>
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        public List<UserFile>? Files { get; set; } 

        public void Mapping(Profile profile) {
            profile.CreateMap<ChatFileMessage, FileMessageVm>()
                .ForMember(f => f.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(f => f.Text, opt => opt.MapFrom(o => o.Text))
                .ForMember(f => f.Description, opt => opt.MapFrom(o => o.Description))
                .ForMember(f => f.Files, opt => opt.MapFrom(o => o.userFiles));
        } 
    }
}