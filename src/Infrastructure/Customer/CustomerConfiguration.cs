using System;
using System.Collections.Generic;
using System.Text;
using Domain.Customer;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Customer;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<CustomerItem>
{
    public void Configure(EntityTypeBuilder<CustomerItem> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(t => t.DateTime).HasConversion(d => d != null ? DateTime.SpecifyKind(d.Value, DateTimeKind.Utc) : d, v => v);

        builder.HasOne<User>().WithMany().HasForeignKey(t => t.UserId);
    }
}
