using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Name).HasMaxLength(110).IsRequired();
            builder.Property(x=>x.Email).HasMaxLength(120).IsRequired();
            builder.Property(x=>x.Phone).HasMaxLength(20).IsRequired();
            builder.Property(x=>x.CreateDate).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
