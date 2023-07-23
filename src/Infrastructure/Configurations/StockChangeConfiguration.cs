using ECom.Domain.Entities;
using ECom.Shared;
using ECom.Shared.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Infrastructure.Configurations;

public class StockChangeConfiguration : IEntityTypeConfiguration<StockChange>
{
  public void Configure(EntityTypeBuilder<StockChange> builder) {
    builder.Property(x => x.Type)
      .HasConversion(new EnumToNumberConverter<StockChangeType, byte>());
  }
}