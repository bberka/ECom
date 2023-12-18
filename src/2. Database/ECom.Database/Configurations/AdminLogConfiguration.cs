using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Database.Configurations;

public class AdminLogConfiguration : IEntityTypeConfiguration<AdminLog>
{
  public void Configure(EntityTypeBuilder<AdminLog> builder) {
    builder.Property(x => x.Level)
           .HasConversion(new EnumToNumberConverter<ResultLevel, byte>())
           .HasDefaultValue(ResultLevel.Info);
  }
}