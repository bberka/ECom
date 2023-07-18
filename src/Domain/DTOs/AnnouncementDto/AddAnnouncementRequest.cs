namespace ECom.Domain.DTOs.AnnouncementDto;

public class AddAnnouncementRequest
{
  public int Order { get; set; }

  [MaxLength(128)]
  public string Message { get; set; }

  public Announcement ToEntity() {
    return new Announcement {
      Order = Order,
      Message = Message,
      RegisterDate = DateTime.Now,
      IsValid = true,
    };
  }

}