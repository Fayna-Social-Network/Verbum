using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.Commands.CreateMessage;

namespace Verbum.WebApi.Models
{
    public class CreateMessageDto :IMapWith<CreateMessageCommand> 
    {
        public string? Text { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<CreateMessageDto, CreateMessageCommand>()
                .ForMember(messCommand => messCommand.Text,
                opt => opt.MapFrom(messDto => messDto.Text));
        }
    }
}
