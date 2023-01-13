
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Verbum.Domain.MessagesDb;
using Verbum.Domain.Groups;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class GroupsThemesConfiguration : IEntityTypeConfiguration<GroupThemes>
        {
            public void Configure(EntityTypeBuilder<GroupThemes> builder)
            {
                builder.HasOne(a => a.group)
                    .WithMany(d => d.groupsThemes)
                    .HasForeignKey(d => d.GroupId);

            }

        }
}
