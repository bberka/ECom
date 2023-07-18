namespace ECom.Domain.Entities;


[Table("Categories", Schema = "ECPrivate")]
[PrimaryKey(nameof(NameKey))]
[Index(nameof(NameKey),nameof(ParentNameKey))]
public class Category : IEntity
{
  public bool IsValid { get; set; } = true;

  [MinLength(ConstantMgr.NameMinLength)]
  [MaxLength(ConstantMgr.NameMaxLength)]
  public string NameKey { get; set; }

  [MinLength(ConstantMgr.NameMinLength)]
  [MaxLength(ConstantMgr.NameMaxLength)]
  public string? ParentNameKey { get; set; }

}