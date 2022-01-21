using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.Users.Commands.UpdateUserCommand;

namespace Verbum.WebApi.Models
{
    public class UpdateUserDto :IMapWith<UpdateUserCommand>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Avatar { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(u => u.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(u => u.FirstName, opt => opt.MapFrom(d => d.FirstName))
                .ForMember(u => u.LastName, opt => opt.MapFrom(d => d.LastName))
                .ForMember(u => u.Avatar, opt => opt.MapFrom(d => d.Avatar));
        }
    }
}
