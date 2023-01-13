using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain;
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class GroupsConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
          
        }
    }
}
