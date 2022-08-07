using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.UserFilesAndMessages.Queries.GetFileMessageQuery
{
    public class FileMessageVm : IMapWith<FileMessage>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Path { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<FileMessage, FileMessageVm>()
                .ForMember(f => f.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(f => f.Type, opt => opt.MapFrom(o => o.Type))
                .ForMember(f => f.Path, opt => opt.MapFrom(o => o.Path));
        } 
    }
}