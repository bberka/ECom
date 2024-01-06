using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs;

public class AnnouncementContentDto
{
  [MinLength(StaticValues.MIN_ANNOUNCEMENT_MESSAGE_LENGTH)]
  [MaxLength(StaticValues.MAX_ANNOUNCEMENT_MESSAGE_LENGTH)]
  public string Message { get; set; } = null!;

  public CultureType CultureType { get; set; }
}