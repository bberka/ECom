﻿using ECom.Domain.Entities;
using ECom.Shared.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Infrastructure.Configurations;

public class PaymentOptionConfiguration : IEntityTypeConfiguration<PaymentOption>
{
  public void Configure(EntityTypeBuilder<PaymentOption> builder) {
    builder.Property(x => x.Type)
      .HasConversion(new EnumToNumberConverter<PaymentType, byte>());
  }
}