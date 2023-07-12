namespace ECom.Domain.Entities;

public class Collection : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; }

  [MaxLength(128)] public string Name { get; set; }

  public int UserId { get; set; }


  //Virtual
  public virtual User User { get; set; }
}