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
    internal sealed class CompanyRouteConfiguration : IEntityTypeConfiguration<CompanyRoute>
    {
        public void Configure(EntityTypeBuilder<CompanyRoute> builder)
        {
            builder.ToTable("CompanyRoutes");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.CompanyId).IsRequired();
            builder.Property(x=>x.RouteId).IsRequired();
            builder.HasIndex(ra => new { ra.CompanyId, ra.RouteId}).IsUnique();
        }
    }
}
