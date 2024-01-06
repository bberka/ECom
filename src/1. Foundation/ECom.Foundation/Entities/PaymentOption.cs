using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("PaymentOptions", Schema = "ECOption")]
public class PaymentOption : IEntity
{
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


  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? IyzicoApiKey { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? IyzicoSecretKey { get; set; }


  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? PayTrMerchantId { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? PayTrMerchantKey { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? PayTrMerchantSalt { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? PayTrInstallment { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]

  public string? StripeApiKey { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]

  public string? StripeClientId { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]

  public string? ShopierUsername { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]

  public string? ShopierPassword { get; set; }


  public bool IncludeTaxToViewPrice { get; set; } = true;

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? LiraBankTransferIban { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? LiraBankTransferSwift { get; set; }


  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? DollarBankTransferIban { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? DollarBankTransferSwift { get; set; }


  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? EuroBankTransferIban { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string? EuroBankTransferSwift { get; set; }


  public object Clone() {
    return MemberwiseClone();
  }

  public PaymentOption CloneCast() {
    return (PaymentOption)MemberwiseClone();
  }
}