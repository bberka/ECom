namespace ECom.Foundation.Entities;

[Table("PaymentOptions", Schema = "ECOption")]
public class PaymentOption : IEntity
{
  public const string LocKey = "payment_option";


  [Key]
  public bool Key { get; set; } = true;


  public DateTime UpdateDate { get; set; }

  public int FreeShipmentMinLimit { get; set; }

  public float Tax { get; set; }


  public bool IsIyzicoEnabled { get; set; } = false;

  public bool IsPayTrEnabled { get; set; } = false;

  public bool IsShopierEnabled { get; set; } = false;

  public bool IsStripeEnabled { get; set; } = false;

  public bool IsBankTransferEnabled { get; set; } = true;

  public bool IsCashOnDeliveryEnabled { get; set; } = false;

  public float StripeTax { get; set; }

  public float IyzicoTax { get; set; }

  public float PayTrTax { get; set; }

  public float ShopierTax { get; set; }

  public float BankTransferTax { get; set; }

  public float CashOnDeliveryTax { get; set; }


  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? IyzicoApiKey { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? IyzicoSecretKey { get; set; }


  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? PayTrMerchantId { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? PayTrMerchantKey { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? PayTrMerchantSalt { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? PayTrInstallment { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]

  public string? StripeApiKey { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]

  public string? StripeClientId { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]

  public string? ShopierUsername { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]

  public string? ShopierPassword { get; set; }


  public bool IncludeTaxToViewPrice { get; set; } = true;

  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? LiraBankTransferIban { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? LiraBankTransferSwift { get; set; }


  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? DollarBankTransferIban { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? DollarBankTransferSwift { get; set; }


  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? EuroBankTransferIban { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string? EuroBankTransferSwift { get; set; }


  public object Clone() {
    return MemberwiseClone();
  }

  public PaymentOption CloneCast() {
    return (PaymentOption)MemberwiseClone();
  }
}