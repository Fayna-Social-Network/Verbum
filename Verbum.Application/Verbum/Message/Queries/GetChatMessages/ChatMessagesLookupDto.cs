using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.ChatOnes;

namespace Verbum.Application.Verbum.Message.Queries.GetChatMessages
{
    public class ChatMessagesLookupDto : IMapWith<ChatMessage>
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public Guid Seller { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public Guid ChatId { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<ChatMessage, ChatMessagesLookupDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.Text, opt => opt.MapFrom(d => d.Text))
                .ForMember(m => m.Seller, opt => opt.MapFrom(d => d.Seller))
                .ForMember(m => m.Timestamp, opt => opt.MapFrom(d => d.Timestamp))
                .ForMember(m => m.IsRead, opt => opt.MapFrom(d => d.IsRead))
                .ForMember(m => m.ChatId, opt => opt.MapFrom(d => d.ChatId));
        } 
    }
}