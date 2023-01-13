using AutoMapper;
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Application.UserGrops.GroupMessage.Queries.GetGroupMessagesByTheme
{
    public class GetGroupMessageLookupDto
    {
        public Guid MessageId { get; set; }
        public Guid SellerId { get; set; }
        public string? Text { get; set; }
        public DateTime dateTime { get; set; }
        public bool isRead { get; set; }
        public List<GroupMessageComment>? comments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GroupMessage, GetGroupMessageLookupDto>()
                .ForMember(dto => dto.MessageId, opt => opt.MapFrom(m => m.Id))
                .ForMember(dto => dto.Text, opt => opt.MapFrom(m => m.Text))
                .ForMember(dto => dto.SellerId, opt => opt.MapFrom(m => m.Seller))
                .ForMember(dto => dto.isRead, opt => opt.MapFrom(m => m.IsRead))
                .ForMember(dto => dto.dateTime, opt => opt.MapFrom(m => m.Timestamp))
                .ForMember(dto => dto.comments, opt => opt.MapFrom(m => m.Comments));
        }
    }
}