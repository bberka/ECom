using ECom.Foundation.Static;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Database.Configurations;

public class ShowCaseConfiguration : IEntityTypeConfiguration<ShowCase>
{
  public void Configure(EntityTypeBuilder<ShowCase> builder) {
    builder.Property(x => x.ShowCaseType)
           .HasConversion(new EnumToNumberConverter<ShowCaseType, byte>());
  }
}