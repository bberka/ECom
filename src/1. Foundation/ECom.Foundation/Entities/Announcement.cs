using ECom.Foundation.DTOs.Request;

namespace ECom.Foundation.Entities;

[Table("Announcements", Schema = "ECPrivate")]
public class Announcement : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

  public DateTime? UpdateDate { get; set; }

  public DateTime ExpireDate { get; set; }

  public bool IsDisabled => ExpireDate < DateTime.Now;
  public int Order { get; set; }

  public Guid ContentId { get; set; }
}