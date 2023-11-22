using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Street).HasMaxLength(80).IsRequired();
            builder.Property(x => x.City).HasMaxLength(50).IsRequired();
            builder.Property(x => x.State).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Zip).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Comments).HasMaxLength(255).IsRequired();
            builder.Property(x => x.LAT).HasMaxLength(255);
            builder.Property(x => x.LNG).HasMaxLength(255);
            builder.Property(x => x.Bagged).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
