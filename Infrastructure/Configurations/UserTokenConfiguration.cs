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
    internal sealed class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserTokens");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Token).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x=>x.ExpireDate).IsRequired();
            builder.Property(x => x.IsExpired).IsRequired();
            builder.Property(x => x.IsRevoked).IsRequired();
            builder.HasIndex(ra => new { ra.UserId });
        }
    }
}