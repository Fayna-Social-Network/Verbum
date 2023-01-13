using Verbum.Application.Common.Mappings;
using Verbum.Domain;
using AutoMapper;
using Verbum.Domain.Groups;

namespace Verbum.Application.UserGrops.UserGroup.Queries.GetAllGroups
{
    public class GroupsAllListLookupDto :IMapWith<Group>
    {
        public Guid id { get; set; }
        public string? GroupName { get; set; }
        public string? GroupAvatarPath { get; set; }
        public bool isGroupClosed { get; set; }
        public bool isBlockedGroup { get; set; }
        public Guid UserId { get; set; }
        public List<GroupThemes>? groupsThemes { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Group, GroupsAllListLookupDto>()
                .ForMember(g => g.id, opt => opt.MapFrom(gl => gl.id))
                .ForMember(g => g.GroupName, opt => opt.MapFrom(gl => gl.GroupName))
                .ForMember(g => g.GroupAvatarPath, opt => opt.MapFrom(gl => gl.GroupAvatarPath))
                .ForMember(g => g.isGroupClosed, opt => opt.MapFrom(gl => gl.isGroupClosed))
                .ForMember(g => g.isBlockedGroup, opt => opt.MapFrom(gl => gl.isBlockedGroup))
                .ForMember(g => g.UserId, opt => opt.MapFrom(gl => gl.UserId))
                .ForMember(g => g.groupsThemes, opt => opt.MapFrom(gl => gl.groupsThemes));
        }
    }
}
