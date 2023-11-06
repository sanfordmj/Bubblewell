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
    internal sealed class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> builder)
        {
            builder.ToTable("CompanyUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.CompanyId).IsRequired();
            builder.Property(x=>x.UserId).IsRequired();
            builder.HasIndex(ra => new { ra.CompanyId, ra.UserId}).IsUnique();
        }
    }
}
