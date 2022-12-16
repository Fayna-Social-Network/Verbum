using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain.Notifications;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasOne(a => a.User)
                .WithMany(d => d.notifications)
                .HasForeignKey(d => d.UserId);
        }
    }
}
