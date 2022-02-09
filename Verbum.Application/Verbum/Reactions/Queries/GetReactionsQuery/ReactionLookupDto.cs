using AutoMapper;
using Verbum.Application.Common.Mappings;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.Reactions.Queries.GetReactionsQuery
{
    public class ReactionLookupDto :IMapWith<MessageReaction>
    {
        public Guid Id { get; set; }
        public string? ReactionName { get; set; }
        public int ReactionCount { get; set; }
        public Guid UserId { get; set; }
        public Guid MessageId { get; set;}

        public void Mapping(Profile profile) {
            profile.CreateMap<MessageReaction, ReactionLookupDto>()
                .ForMember(r => r.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(r => r.ReactionName, opt => opt.MapFrom(x => x.ReactionName))
                .ForMember(r => r.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(r => r.ReactionCount, opt => opt.MapFrom(x => x.ReactionCount))
                .ForMember(r => r.UserId, opt => opt.MapFrom(x => x.UserId));
        }

    }
}
