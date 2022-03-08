using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.UserContacts.Commands.AddContactToUser;

namespace Verbum.WebApi.Models.UserContacts
{
    public class AddContactDto :IMapWith<AddContactToUserCommand>
    {
        public Guid Contact { get; set; }
        public Guid Userid { get; set; }
        public string? Name { get; set; }
        public string? Group { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<AddContactDto, AddContactToUserCommand>()
                .ForMember(c => c.Contact, opt => opt.MapFrom(x => x.Contact))
                .ForMember(c => c.UserId, opt => opt.MapFrom(x => x.Userid))
                .ForMember(c => c.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(c => c.Group, opt => opt.MapFrom(x => x.Group));
        }
    }
}
