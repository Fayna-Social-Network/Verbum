
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    
        public class GroupsMessagesConfiguration : IEntityTypeConfiguration<GroupMessage>
        {
            public void Configure(EntityTypeBuilder<GroupMessage> builder)
            {
                builder.HasOne(a => a.GroupTheme)
                    .WithMany(d => d.groupMessages)
                    .HasForeignKey(d => d.GroupThemeId);

            }

        }
}
