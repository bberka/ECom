namespace ECom.Domain.Entities;

[Table("SubCategories", Schema = "ECPrivate")]
public class SubCategory : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public bool IsValid { get; set; }

  [MinLength(ConstantMgr.NameMinLength)]
  [MaxLength(ConstantMgr.NameMaxLength)]
  public string Name { get; set; }

  public int CategoryId { get; set; }
}