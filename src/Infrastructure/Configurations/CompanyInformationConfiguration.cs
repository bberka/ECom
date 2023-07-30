using ECom.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

public class CompanyInformationConfiguration : IEntityTypeConfiguration<CompanyInformation>
{
  private static readonly List<CompanyInformation> _companyInformations = new() {
    new CompanyInformation {
      CompanyAddress = "Address",
      CompanyName = "CompanyName",
      ContactEmail = "contact@support.com",
      Description = "Company Description",
      DomainUrl = "www.company.com",
      FacebookLink = "facebook.com/company",
      InstagramLink = "instagram.com/company",
      Key = true,
      PhoneNumber = "5526667788",
      WebApiUrl = "api.company.com",
      WhatsApp = "5526667788",
      YoutubeLink = "yt.com/company"
    }
  };

  public void Configure(EntityTypeBuilder<CompanyInformation> builder) {
    builder.HasData(_companyInformations);
  }
}