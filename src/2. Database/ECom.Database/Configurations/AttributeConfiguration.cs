using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Database.Configurations;

public class AttributeConfiguration : IEntityTypeConfiguration<ProductAttributeType>
{
  public void Configure(EntityTypeBuilder<ProductAttributeType> builder) {
    builder.HasData(SeedData.ProductAttributes);
  }
}