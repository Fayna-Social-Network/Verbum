using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.Commands.UpdateMessage;

namespace Verbum.WebApi.Models
{
    public class UpdateMessageDto :IMapWith<UpdateMessageCommand> 
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<UpdateMessageDto, UpdateMessageCommand>()
               .ForMember(messCommand => messCommand.Id,
                   opt => opt.MapFrom(messDto => messDto.Id))
               .ForMember(messCommand => messCommand.Text,
                   opt => opt.MapFrom(messDto => messDto.Text));
        }
    }
}
