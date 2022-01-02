using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Queries.GetMessageList
{
    public class MessageLookupDto :IMapWith<Message>
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }


        public void Mapping(Profile profile) {
            profile.CreateMap<Message, MessageLookupDto>()
                .ForMember(messDto => messDto.Id,
                opt => opt.MapFrom(mess => mess.Id))
                 .ForMember(messDto => messDto.Text,
                opt => opt.MapFrom(mess => mess.Text));
        }
    }
}
