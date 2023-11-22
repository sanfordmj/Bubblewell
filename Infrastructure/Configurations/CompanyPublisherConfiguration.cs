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
    internal sealed class CompanyPublisherConfiguration : IEntityTypeConfiguration<CompanyPublisher>
    {
        public void Configure(EntityTypeBuilder<CompanyPublisher> builder)
        {
            builder.ToTable("CompanyPublishers");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.CompanyId).IsRequired();
            builder.Property(x=>x.PublisherId).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
            builder.HasIndex(ra => new { ra.CompanyId, ra.PublisherId}).IsUnique();
        }
    }
}
