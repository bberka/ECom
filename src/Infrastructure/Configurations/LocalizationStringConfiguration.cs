using ECom.Domain.Entities;
using ECom.Shared.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Infrastructure.Configurations;

public class LocalizationStringConfiguration : IEntityTypeConfiguration<LocalizationString>
{
  private static readonly List<LocalizationString> _data = new() {
    new LocalizationString {
      Language = LanguageType.English,
      Key = "hello",
      Value = "Hello"
    },
    new LocalizationString {
      Language = LanguageType.Turkish,
      Key = "hello",
      Value = "Merhaba"
    }
  };

  public void Configure(EntityTypeBuilder<LocalizationString> builder) {
    builder.Property(x => x.Language)
      .HasConversion(new EnumToNumberConverter<LanguageType, byte>());

    builder.HasData(_data);
  }
}