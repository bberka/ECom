using ECom.Foundation.Enum;

namespace ECom.Foundation.DTOs;

public class AnnouncementContentDto
{
  [MinLength(ConstantContainer.MinAnnouncementMessageLength)]
  [MaxLength(ConstantContainer.MaxAnnouncementMessageLength)]
  public string Message { get; set; } = null!;

  public Language Language { get; set; }
}