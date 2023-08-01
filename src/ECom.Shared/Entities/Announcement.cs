namespace ECom.Shared.Entities;

[Table("Announcements", Schema = "ECPrivate")]
public class Announcement : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  //public DateTime? DeleteDate { get; set; }
  public DateTime ExpireDate { get; set; }

  public bool IsDisabled => ExpireDate < DateTime.Now;
  public int Order { get; set; }

  [MaxLength(ValidationSettings.MaxMessageLength)]
  public string Message { get; set; }
  public static Announcement FromDto(AnnouncementAddRequestDto requestDto) {
    return new Announcement {
      Order = requestDto.Order,
      Message = requestDto.Message,
      RegisterDate = DateTime.Now,
      ExpireDate = requestDto.ExpireDate 
    };
  }

  public static Announcement FromDto(UpdateAnnouncementRequest request) {
    return new Announcement {
      Order = request.Order,
      Message = request.Message,
      RegisterDate = DateTime.Now,
      Id = request.Id
    };
  }
}