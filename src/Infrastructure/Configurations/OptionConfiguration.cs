﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

public class OptionConfiguration : IEntityTypeConfiguration<Option>
{
  public void Configure(EntityTypeBuilder<Option> builder) {
    builder.HasData(new Option());
    builder.HasData(new Option() {
      IsRelease = false
    });
  }
}