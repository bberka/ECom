namespace ECom.Shared.DTOs;

public class AddAnnouncementRequest
{
    public int Order { get; set; }

    [MaxLength(128)]
    public string Message { get; set; } = null!;
    public DateTime ExpireDate { get; set; }
}