﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verbum.Domain;

namespace Verbum.Persistence.EntityTypeConfigurations
{
    public class UserContactConfiguration : IEntityTypeConfiguration<UserContact>
    {
        public void Configure(EntityTypeBuilder<UserContact> builder)
        {
            builder.HasOne<VerbumUser>(a => a.User)
                .WithMany(d => d.Contacts)
                .HasForeignKey(a => a.Contact);
                
        }
    }
}