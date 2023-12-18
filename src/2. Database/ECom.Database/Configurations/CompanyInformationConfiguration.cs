using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Database.Configurations;

public class CompanyInformationConfiguration : IEntityTypeConfiguration<CompanyInformation>
{
  public void Configure(EntityTypeBuilder<CompanyInformation> builder) {
    builder.HasData(SeedData.CompanyInformation);
  }
}