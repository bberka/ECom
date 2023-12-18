using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Database.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder) {
    builder.Property(x => x.OrderStatus)
           .HasConversion(new EnumToNumberConverter<OrderStatus, byte>())
           .HasDefaultValue(OrderStatus.Pending);
  }
}