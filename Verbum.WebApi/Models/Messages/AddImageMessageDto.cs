using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Verbum.ImageMessages.Commands.AddImagesMessageCommand;


namespace Verbum.WebApi.Models.Messages
{
    public class AddImageMessageDto 
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string[]? ImagePaths { get; set; }
    }
}
