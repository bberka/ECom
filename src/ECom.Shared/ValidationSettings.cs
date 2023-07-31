using System.Configuration;
using ECom.Shared.Models;

namespace ECom.Shared;

public static class ValidationSettings
{
  public const int MinGlobalStringLength = 1;
  public const int MaxGlobalStringLength = 1000;
  public const int MinPasswordLength = 6;
  public const int MaxPasswordLength = 32;
  public const int MinHashedPasswordLength = 1;
  public const int MaxHashedPasswordLength = 256;
  public const int MinNameLength = 2;
  public const int MaxNameLength = 50;
  public const int MinPhoneLength = 8;
  public const int MaxPhoneLength = 14;
  public const int MinAddressLength = 3;
  public const int MaxAddressLength = 200;
  public const int MinCityLength = 2;
  public const int MaxCityLength = 100;
  public const int MinCountryLength = 2;
  public const int MaxCountryLength = 100;
  public const int MinPostalCodeLength = 2;
  public const int MaxPostalCodeLength = 20;
  public const int MinDescriptionLength = 2;
  public const int MaxDescriptionLength = 500;
  public const int MinProductDescriptionLength = 20;
  public const int MaxProductDescriptionLength = int.MaxValue;
  public const int MinTitleLength = 8;
  public const int MaxTitleLength = 128;
  public const int MinMessageLength = 4;
  public const int MaxMessageLength = 128;
  public const int MinCultureLength = 2;
  public const int MaxCultureLength = 4;
  public const int MaxMemoLength = 128;
  public const int MaxCouponLength = 32;
  public const int MinCouponLength = 6;
  public const int MaxTokenLength = 512;
  public const int MinTokenLength = 512;
  public const int MaxProductCommentLength = 1000;
  public const int MinProductCommentLength = 16;
  public const int MinProductShortLength = 512;
  public const int MaxProductShortLength = 6;
  public const int MaxImageAltLength = 64;
  public const int MaxOperationLength = 64;
  public const int MaxErrorCodeLength = 128;
  public const int MaxDomainLength = 512;
  public const int MinEmailLength = 2;
  public const int MaxEmailLength = 512;
  public const int MaxReasonLength = 64;

  //public static readonly IReadOnlyCollection<StringValidation> Validations = new List<StringValidation>() {
  //    new (ValidationType.Address,MinAddressLength, MaxAddressLength, "address"),
  //    new (ValidationType.City,MinCityLength, MaxCityLength, "city"),
  //    new (ValidationType.Country,MinCountryLength, MaxCountryLength, "country"),
  //    new (ValidationType.Coupon,MinCouponLength, MaxCouponLength, "coupon"),
  //    new (ValidationType.Description,MinDescriptionLength, MaxDescriptionLength, "description"),
  //    new (ValidationType.Domain,0, MaxDomainLength, "domain"),
  //    new (ValidationType.EmailAddress,2, MaxEmailLength, "email_address"),
  //    new (ValidationType.ErrorCode,0, MaxErrorCodeLength, "errorCode"),
  //    new (ValidationType.Hash,MinHashedPasswordLength, MaxHashedPasswordLength, "hash"),
  //    new (ValidationType.ImageAlt,0, MaxImageAltLength, "imageAlt"),
  //    new (ValidationType.Message,MinMessageLength, MaxMessageLength, "message"),
  //    new (ValidationType.Name,MinNameLength, MaxNameLength, "name"),
  //    new (ValidationType.Password,MinPasswordLength, MaxPasswordLength, "password"),
  //    new (ValidationType.PhoneNumber,MinPhoneLength, MaxPhoneLength, "phone"),
  //    new (ValidationType.PostalCode,MinPostalCodeLength, MaxPostalCodeLength, "postal_code"),
  //    new (ValidationType.ProductComment,MinProductCommentLength, MaxProductCommentLength, "product_comment"),
  //    new (ValidationType.ProductDescription,MinProductDescriptionLength, MaxProductDescriptionLength, "product_description"),
  //    new (ValidationType.ProductShortDescription,MinProductShortLength, MaxProductShortLength, "product_short"),
  //    new (ValidationType.Reason,0, MaxReasonLength, "reason"),
  //    new (ValidationType.Title,MinTitleLength, MaxTitleLength, "title"),
  //    new (ValidationType.Token,MinTokenLength, MaxTokenLength, "token"),
  //    new (ValidationType.Operation,0, MaxOperationLength, "operation"),
  //    new (ValidationType.Culture,MinCultureLength, MaxCultureLength, "culture"),
  //    new (ValidationType.Memo,0, MaxMemoLength, "memo"),
  //};
  //public static StringValidation? GetValidation(ValidationType type) => Validations.FirstOrDefault(x => x.Type == type);
}