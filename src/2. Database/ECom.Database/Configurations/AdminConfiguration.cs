using ECom.Foundation.Static;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Database.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
  public void Configure(EntityTypeBuilder<Admin> builder) {
    builder.Navigation(x => x.Role).AutoInclude();
    builder.HasData(SeedData.Admins);
    builder.Property(x => x.TwoFactorType)
           .HasConversion(new EnumToNumberConverter<TwoFactorType, byte>())
           .HasDefaultValue(TwoFactorType.None);
  }
}