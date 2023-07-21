using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[Table("Announcements", Schema = "ECPrivate")]
public class Announcement : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }
  public DateTime ExpireDate { get; set; }

  public int Order { get; set; }

  [MaxLength(ValidationSettings.MaxMessageLength)]
  public string Message { get; set; }
  public static Announcement FromDto(AddAnnouncementRequest request) {
    return new Announcement {
      Order = request.Order,
      Message = request.Message,
      RegisterDate = DateTime.Now,
      ExpireDate = request.ExpireDate 
    };
  }

  public static Announcement FromDto(UpdateAnnouncementRequest request) {
    return new Announcement {
      Order = request.Order,
      Message = request.Message,
      RegisterDate = DateTime.Now,
      Id = request.Id
    };
  }
}