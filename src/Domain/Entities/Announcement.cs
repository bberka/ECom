namespace ECom.Domain.Entities;

[Table("Announcements", Schema = "ECPrivate")]
public class Announcement : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Range(0, int.MaxValue)]
  public int Id { get; set; }

  public int Order { get; set; }

  [MaxLength(128)]
  public string Message { get; set; }

  public DateTime RegisterDate { get; set; }

  public bool IsValid { get; set; }

  public static Announcement FromDto(AddAnnouncementRequest request) {
    return new Announcement {
      Order = request.Order,
      Message = request.Message,
      RegisterDate = DateTime.Now,
      IsValid = true
    };
  }

  public static Announcement FromDto(UpdateAnnouncementRequest request) {
    return new Announcement {
      Order = request.Order,
      Message = request.Message,
      RegisterDate = DateTime.Now,
      IsValid = true,
      Id = request.Id
    };
  }

}