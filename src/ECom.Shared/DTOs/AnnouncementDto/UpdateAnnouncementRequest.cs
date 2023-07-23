namespace ECom.Shared.DTOs.AnnouncementDto;

public class UpdateAnnouncementRequest
{
  public Guid Id { get; set; }
  public int Order { get; set; }

  [MaxLength(ValidationSettings.MaxMessageLength)]
  [MinLength(ValidationSettings.MinMessageLength)]
  public string Message { get; set; } = null!;

  public DateTime ExpireDate { get; set; }

}
