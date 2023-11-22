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
    internal sealed class UserRouteConfiguration : IEntityTypeConfiguration<UserRoute>
    {
        public void Configure(EntityTypeBuilder<UserRoute> builder)
        {
            builder.ToTable("UserRoutes");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.UserId).IsRequired();
            builder.Property(x=>x.RouteId).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
            builder.HasIndex(ra => new { ra.UserId, ra.RouteId}).IsUnique();
        }
    }
}
