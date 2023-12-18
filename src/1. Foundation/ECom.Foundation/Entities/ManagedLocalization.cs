using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("ManagedLocalization", Schema = "ECPrivate")]
[PrimaryKey(nameof(Key), nameof(Culture))]
public class ManagedLocalization : IEntity
{
  public Guid Key { get; set; } = Guid.NewGuid();

  public LanguageType Culture { get; set; } = ConstantContainer.DefaultLanguage;


  public string Value { get; set; }
}