using ECom.Foundation.Static;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Database.Configurations;

public class SmtpOptionConfiguration : IEntityTypeConfiguration<SmtpOption>
{
  public void Configure(EntityTypeBuilder<SmtpOption> builder) {
    builder.Property(x => x.SmtpHostType)
           .HasConversion(new EnumToNumberConverter<SmtpHostType, byte>());
  }
}