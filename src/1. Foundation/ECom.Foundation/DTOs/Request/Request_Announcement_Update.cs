namespace ECom.Foundation.DTOs.Request;

public class Request_Announcement_Update
{
  public Guid Id { get; set; }
  public int Order { get; set; }

  [MaxLength(ConstantContainer.MaxMessageLength)]
  [MinLength(ConstantContainer.MinMessageLength)]
  public string Message { get; set; } = null!;

  public DateTime ExpireDate { get; set; }
}