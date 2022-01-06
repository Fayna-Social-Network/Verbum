using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.Message.Commands.CreateMessage;

namespace Verbum.WebApi.Models
{
    public class SendMessageDto :IMapWith<SendMessageCommand> 
    {
        public string? Text { get; set; }
        public Guid Seller { get; set; }
        public Guid UserId { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<SendMessageDto, SendMessageCommand>()
                .ForMember(messCommand => messCommand.Text,
                opt => opt.MapFrom(messDto => messDto.Text))
                .ForMember(m => m.Seller, opt => opt.MapFrom(m => m.Seller))
                .ForMember(m => m.UserId, opt => opt.MapFrom(m => m.UserId));

        }
    }
}
