
namespace ECom.Shared.DTOs.AnnouncementDto;

public class UpdateAnnouncementRequest
{
  [Range(0, int.MaxValue)]
  public int Id { get; set; }

  public int Order { get; set; }

  [MaxLength(128)]
  [MinLength(6)]
  public string Message { get; set; } = null!;

  public bool IsValid { get; set; }


}
