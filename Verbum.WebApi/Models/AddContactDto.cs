using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.UserContacts.Commands.AddContactToUser;

namespace Verbum.WebApi.Models
{
    public class AddContactDto :IMapWith<AddContactToUserCommand>
    {
        public Guid Contact { get; set; }
        public Guid Userid { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<AddContactDto, AddContactToUserCommand>()
                .ForMember(c => c.Contact, opt => opt.MapFrom(x => x.Contact))
                .ForMember(c => c.UserId, opt => opt.MapFrom(x => x.Userid));
        }
    }
}
