using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Database.Configurations;

public class OptionConfiguration : IEntityTypeConfiguration<Option>
{
  public void Configure(EntityTypeBuilder<Option> builder) {
    builder.HasData(SeedData.Option);
  }
}