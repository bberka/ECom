using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Infrastructure.Configurations;

public class ShowCaseConfiguration : IEntityTypeConfiguration<ShowCase>
{
  public void Configure(EntityTypeBuilder<ShowCase> builder) {
    builder.Property(x => x.ShowCaseType)
      .HasConversion(new EnumToNumberConverter<ShowCaseType, byte>());
  }
}