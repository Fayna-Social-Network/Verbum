using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class UserBlackListConfiguration :IEntityTypeConfiguration<UserBlackList>
    {
        public void Configure(EntityTypeBuilder<UserBlackList> builder) {
            builder.HasOne<VerbumUser>(a => a.BlockUser)
                .WithMany(d => d.UserBlackLists)
                .HasForeignKey(a => a.UserId);
        }
    }
}
