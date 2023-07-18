namespace ECom.Domain.DTOs.AnnouncementDto;

public class UpdateAnnouncementRequest
{
  [Range(0, int.MaxValue)]
  public int Id { get; set; }

  public int Order { get; set; }

  [MaxLength(128)]
  [MinLength(6)]
  public string Message { get; set; }

  public bool IsValid { get; set; }

  public Announcement ToEntity() {
    return new Announcement {
      Order = Order,
      Message = Message,
      RegisterDate = DateTime.Now,
      IsValid = true,
      Id =  Id
    };
  }
}
