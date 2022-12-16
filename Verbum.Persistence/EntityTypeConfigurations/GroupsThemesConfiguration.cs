
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Verbum.Domain.MessagesDb;
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Persistence.EntityTypeConfigurations
{
        public class GroupsThemesConfiguration : IEntityTypeConfiguration<GroupsThemes>
        {
            public void Configure(EntityTypeBuilder<GroupsThemes> builder)
            {
                builder.HasOne(a => a.group)
                    .WithMany(d => d.groupsThemes)
                    .HasForeignKey(d => d.GroupId);

            }

        }
}
