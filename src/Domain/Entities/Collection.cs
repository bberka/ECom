namespace ECom.Domain.Entities;

[Table("Collections", Schema = "ECPrivate")]
public class Collection : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MaxLength(ValidationSettings.MaxNameLength)]
  [MinLength(ValidationSettings.MinNameLength)]
  public string Name { get; set; }
  public Guid UserId { get; set; }
  //Virtual
  public virtual User User { get; set; }
}