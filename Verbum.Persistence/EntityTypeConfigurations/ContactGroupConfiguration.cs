using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.Users;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class ContactGroupConfiguration : IEntityTypeConfiguration<ContactGroup>
    {
        public void Configure(EntityTypeBuilder<ContactGroup> builder)
        {
            builder.HasData(new ContactGroup { Id = Guid.NewGuid(), GroupName = "General" });
        }
    }
}
