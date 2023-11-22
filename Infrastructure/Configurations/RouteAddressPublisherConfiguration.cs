using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal sealed class RouteAddressPublisherConfiguration : IEntityTypeConfiguration<RouteAddressPublisher>
    {
        public void Configure(EntityTypeBuilder<RouteAddressPublisher> builder)
        {
            builder.ToTable("RouteAddressPublishers");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.RouteAddressId).IsRequired();
            builder.Property(x=>x.PublisherId).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
            builder.HasIndex(ra => new { ra.RouteAddressId, ra.PublisherId}).IsUnique();
        }
    }
}
