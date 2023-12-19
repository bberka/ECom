using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("Contents", Schema = "ECPrivate")]
[PrimaryKey(nameof(Id), nameof(Culture))]
public class Content : IEntity
{
  public const string LocKey = "content";
  public Guid Id { get; set; }
  public Language Culture { get; set; }

  [MaxLength(int.MaxValue)]
  public string Value { get; set; }
}