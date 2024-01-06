using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Contents", Schema = "ECPrivate")]
[PrimaryKey(nameof(Id), nameof(Culture))]
public class Content : IEntity
{
  public Guid Id { get; set; }
  public CultureType Culture { get; set; }

  [MaxLength(int.MaxValue)]
  public string Value { get; set; }
}