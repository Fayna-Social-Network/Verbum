using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.ContactGroups.Commands.UpdateContactGroup;
using AutoMapper;

namespace Verbum.WebApi.Models.contactGroup
{
    public class UpdateContactGroupDto : IMapWith<UpdateContactGroupCommand>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<UpdateContactGroupDto, UpdateContactGroupCommand>()
                .ForMember(g => g.GroupId, opt => opt.MapFrom(x => x.Id))
                .ForMember(g => g.NewGroupName, opt => opt.MapFrom(x => x.Name));
        }
    }
}
