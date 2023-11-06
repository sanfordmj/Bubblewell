using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Infrastructure.Configurations
{
    internal sealed class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddresses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AddressId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Visible).IsRequired();
            builder.Property(x => x.ModifyDate).IsRequired();
            builder.HasIndex(ra => new { ra.UserId, ra.AddressId}).IsUnique();
        }
    }
}