using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Infrastructure.Configurations;

public class LocalizationStringConfiguration : IEntityTypeConfiguration<LocalizationString>
{
  public void Configure(EntityTypeBuilder<LocalizationString> builder) {
    builder.Property(x => x.Language)
      .HasConversion(new EnumToNumberConverter<LanguageType, byte>());

    builder.HasData(_data);
  }

  private static readonly List<LocalizationString> _data = new List<LocalizationString>() {
    new LocalizationString() {
      Language = LanguageType.English,
      Key = "hello",
      Value = "Hello",
    },
    new LocalizationString() {
      Language =  LanguageType.Turkish,
      Key = "hello",
      Value = "Merhaba",
    }
  };
}