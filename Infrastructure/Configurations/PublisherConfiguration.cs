using Domain.Entities;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal sealed class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("Publishers");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name).HasMaxLength(80).IsRequired();
            builder.Property(x=>x.Abbreviation).HasMaxLength(4).IsRequired();
            builder.Property(x => x.Earnings);
        }
    }
}