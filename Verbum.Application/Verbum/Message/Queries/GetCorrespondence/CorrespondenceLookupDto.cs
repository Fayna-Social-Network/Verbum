using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.Message.Queries.GetCorrespondence
{
    public class CorrespondenceLookupDto : IMapWith<Messages>
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public Guid Seller { get; set; }
        public bool isRead { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid UserId { get; set; }


        public void Mapping(Profile profile) {
            profile.CreateMap<Messages, CorrespondenceLookupDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(dto => dto.Text, opt => opt.MapFrom(m => m.Text))
                .ForMember(dto => dto.Seller, opt => opt.MapFrom(m => m.Seller))
                .ForMember(dto => dto.isRead, opt => opt.MapFrom(m => m.IsRead))
                .ForMember(dto => dto.Timestamp, opt => opt.MapFrom(m => m.Timestamp))
                .ForMember(dto => dto.UserId, opt => opt.MapFrom(m => m.UserId));
            
        }
    }
}
