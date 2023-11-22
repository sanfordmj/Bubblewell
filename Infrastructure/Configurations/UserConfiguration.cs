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
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.UserType).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(120);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.Hash).HasMaxLength(500).IsRequired();
            builder.Property(x=>x.FirstName).HasMaxLength(120).IsRequired();
            builder.Property(x=>x.LastName).HasMaxLength(120).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(254);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.CellPhone).HasMaxLength(18).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}