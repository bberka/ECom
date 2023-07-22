

namespace ECom.Domain.Entities;

[Table("PaymentOptions", Schema = "ECOption")]
public class PaymentOption : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  public PaymentType Type { get; set; }
  
  public float Tax { get; set; }

  [MaxLength(ValidationSettings.MaxTokenLength)]
  public string? SecretKey { get; set; }

  [MaxLength(ValidationSettings.MaxTokenLength)]
  public string? ClientId { get; set; }

  [MaxLength(ValidationSettings.MaxTokenLength)]
  public string? ApiKey { get; set; }

  [MaxLength(ValidationSettings.MaxTokenLength)]
  public string? Username { get; set; }
  [MaxLength(ValidationSettings.MaxTokenLength)]
  public string? Password { get; set; }

}
