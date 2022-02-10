using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.ImageMessages.Commands.AddImagesMessageCommand;


namespace Verbum.WebApi.Models.Messages
{
    public class AddImageMessageDto :IMapWith<AddImagesMessageCommand>
    {
        public Guid SellerId { get; set; }
        public Guid UserId { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }
        public string[]? DbImagePath { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<AddImageMessageDto, AddImagesMessageCommand>()
                .ForMember(x => x.SellerId, opt => opt.MapFrom(a => a.SellerId))
                .ForMember(x => x.UserId, opt => opt.MapFrom(a => a.UserId))
                .ForMember(x => x.Header, opt => opt.MapFrom(a => a.Header))
                .ForMember(x => x.Description, opt => opt.MapFrom(a => a.Description))
                .ForMember(x => x.DbImagePath, opt => opt.MapFrom(a => a.DbImagePath));
        }
    }
}
