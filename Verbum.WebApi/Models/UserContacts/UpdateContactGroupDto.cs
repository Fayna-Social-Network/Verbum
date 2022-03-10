using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.UserContacts.Commands.ChangeContactGroup;

namespace Verbum.WebApi.Models.UserContacts
{
    public class UpdateContactGroupDto :IMapWith<ChangeContactGroupCommand>
    {
        public Guid ContactId { get; set; }
        public Guid GroupId { get; set; }
        public string? ContactName { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<UpdateContactGroupDto, ChangeContactGroupCommand>()
                .ForMember(x => x.ContactId, opt => opt.MapFrom(a => a.ContactId))
                .ForMember(x => x.ContactName, opt => opt.MapFrom(a => a.ContactName))
                .ForMember(x => x.GroupId, opt => opt.MapFrom(a => a.GroupId));
        }
    }
}
