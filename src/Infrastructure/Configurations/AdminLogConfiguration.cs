using ECom.Domain.Entities;
using ECom.Shared;
using ECom.Shared.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Infrastructure.Configurations;

public class AdminLogConfiguration : IEntityTypeConfiguration<AdminLog>
{
  public void Configure(EntityTypeBuilder<AdminLog> builder) {
    builder.Property(x => x.Level)
      .HasConversion(new EnumToNumberConverter<CustomResultLevel, byte>())
      .HasDefaultValue(CustomResultLevel.Info);
  }
}