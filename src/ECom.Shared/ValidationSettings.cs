﻿namespace ECom.Shared;

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
  public const int MaxEmailLength = 512;
  public const int MaxReasonLength = 64;
}