
namespace ECom.Shared.DTOs.AnnouncementDto;

public class AddAnnouncementRequest
{
  public int Order { get; set; }

  [MaxLength(128)]
  public string Message { get; set; } = null!;


}