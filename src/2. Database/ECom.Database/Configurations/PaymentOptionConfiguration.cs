using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Database.Configurations;

public class PaymentOptionConfiguration : IEntityTypeConfiguration<PaymentOption>
{
  public void Configure(EntityTypeBuilder<PaymentOption> builder) {
    // builder.Property(x => x.Type)
    //        .HasConversion(new EnumToNumberConverter<PaymentType, byte>());
  }
}