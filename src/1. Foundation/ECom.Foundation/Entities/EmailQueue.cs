namespace ECom.Foundation.Entities;

[Table("EmailQueue", Schema = "ECPrivate")]
public sealed class EmailQueue : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;
  public DateTime? SentDate { get; set; }

  public Guid? UserId { get; set; }

  public string EmailAddress { get; set; }

  [MaxLength(ConstantContainer.MaxEmailTitleLength)]
  public string Title { get; set; }

  [MaxLength(ConstantContainer.MaxEmailContentLength)]
  public string Content { get; set; }

  public int RetryCount { get; set; } = 0;
  public DateTime? NextRetryDate { get; set; }
  public DateTime? LastRetryDate { get; set; }

  public User? User { get; set; }
}