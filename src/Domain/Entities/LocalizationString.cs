namespace ECom.Domain.Entities;

[Table("LocalizationStrings",Schema = "ECPrivate")]
[PrimaryKey(nameof(Key),nameof(Language))]
public class LocalizationString : IEntity
{
  [MaxLength(128)]
  public string Key { get; set; }
  public LanguageType Language { get; set; }

  [MaxLength(5000)]
  public string Value { get; set; }
}