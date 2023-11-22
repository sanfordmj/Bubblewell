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
    internal sealed class RouteAddressConfiguration : IEntityTypeConfiguration<RouteAddress>
    {
        public void Configure(EntityTypeBuilder<RouteAddress> builder)
        {
            builder.ToTable("RouteAddresses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AddressId).IsRequired();
            builder.Property(x => x.RouteId).IsRequired();
            builder.Property(x => x.Visible).IsRequired();
            builder.Property(x => x.Reviewed).IsRequired();
            builder.Property(x => x.Position).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
            builder.HasIndex(ra => new { ra.RouteId, ra.AddressId}).IsUnique();
        }
    }
}