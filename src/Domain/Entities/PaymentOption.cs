namespace ECom.Domain.Entities;

public class PaymentOption : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  /// <summary>
  ///   None = 0,
  ///   Iyzico = 1,
  ///   PayTR = 2,
  ///   Shopier = 3,
  ///   Stripe = 4,
  ///   Transfer = 5,
  ///   CashOnDelivery = 6,
  /// </summary>

  public int Type { get; set; }

  /// <summary>
  ///   None = 0,
  ///   Iyzico = 1,
  ///   PayTR = 2,
  ///   Shopier = 3,
  ///   Stripe = 4,
  ///   Transfer = 5,
  ///   CashOnDelivery = 6,
  /// </summary>

  [MaxLength(32)]
  public string TypeName { get; set; }


  public bool IsValid { get; set; }


  [MaxLength(64)] public string Name { get; set; }


  public float Tax { get; set; }


  [MaxLength(512)] public string? SecretKey { get; set; }

  [MaxLength(512)] public string? ClientId { get; set; }

  [MaxLength(512)] public string? ApiKey { get; set; }

  [MaxLength(512)] public string? Username { get; set; }

  [MaxLength(512)] public string? Password { get; set; }


  [MinLength(2)] [MaxLength(4)] public string Culture { get; set; } = ConstantMgr.DefaultCulture;
}