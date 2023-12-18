﻿using FluentValidation.Resources;

namespace ECom.Business.Validators;

public class ValidationLanguageManager : LanguageManager
{
  public ValidationLanguageManager() {
    AddTranslation("en", CustomValidationType.TooShort.ToString(), "'{PropertyName}' is too short.");
    AddTranslation("en", CustomValidationType.TooLong.ToString(), "'{PropertyName}' is too long.");
    AddTranslation("en", CustomValidationType.Expired.ToString(), "'{PropertyName}' is expired.");
    AddTranslation("en", CustomValidationType.AlreadyDeleted.ToString(), "'{PropertyName}' already deleted.");
    AddTranslation("en", CustomValidationType.AlreadyExists.ToString(), "'{PropertyName}' is already exist.");
    AddTranslation("en", CustomValidationType.AlreadyInUse.ToString(), "'{PropertyName}' is already in use.");
    AddTranslation("en", CustomValidationType.NotFound.ToString(), "'{PropertyName}' is not found.");
    AddTranslation("en", CustomValidationType.NotVerified.ToString(), "'{PropertyName}' is not verified.");
    AddTranslation("en", CustomValidationType.NotValid.ToString(), "'{PropertyName}' is invalid.");
    AddTranslation("en", CustomValidationType.NotExist.ToString(), "'{PropertyName}' does not exist.");
    AddTranslation("en", CustomValidationType.CanNotBeUsed.ToString(), "'{PropertyName}' can not be used.");
    AddTranslation("en", CustomValidationType.CanNotContainSpace.ToString(), "'{PropertyName}' can not contain space.");
    AddTranslation("en", CustomValidationType.MustContainSpecialCharacter.ToString(),
                   "'{PropertyName}' must contain at least 1 special character.");
    AddTranslation("en", CustomValidationType.MustContainDigit.ToString(),
                   "'{PropertyName}' must contain at least 1 digit.");
    AddTranslation("en", CustomValidationType.MustContainLowerCase.ToString(),
                   "'{PropertyName}' must contain at least 1 lower case character.");
    AddTranslation("en", CustomValidationType.MustContainUpperCase.ToString(),
                   "'{PropertyName}' must contain at least 1 upper case character.");
    AddTranslation("en", CustomValidationType.Wrong.ToString(), "'{PropertyName}' is wrong.");
    AddTranslation("en", CustomValidationType.InvalidAccount.ToString(), "Account is invalid.");
    AddTranslation("en", CustomValidationType.AccountCanNotBeUsed.ToString(), "This account can not be used.");
    AddTranslation("en", CustomValidationType.MustBeSame.ToString(), "{PropertyName} must be same.");
    AddTranslation("en", CustomValidationType.CanNotBeSame.ToString(), "{PropertyName} can not be same.");

    AddTranslation("tr", CustomValidationType.TooShort.ToString(), "'{PropertyName}' çok kısa.");
    AddTranslation("tr", CustomValidationType.TooLong.ToString(), "'{PropertyName}' çok uzun.");
    AddTranslation("tr", CustomValidationType.Expired.ToString(), "'{PropertyName}' süresi doldu.");
    AddTranslation("tr", CustomValidationType.AlreadyDeleted.ToString(), "'{PropertyName}' zaten silindi.");
    AddTranslation("tr", CustomValidationType.AlreadyExists.ToString(), "'{PropertyName}' zaten var.");
    AddTranslation("tr", CustomValidationType.AlreadyInUse.ToString(), "'{PropertyName}' zaten kullanılıyor.");
    AddTranslation("tr", CustomValidationType.NotFound.ToString(), "'{PropertyName}' bulunamadı.");
    AddTranslation("tr", CustomValidationType.NotVerified.ToString(), "'{PropertyName}' doğrulanması gerekli.");
    AddTranslation("tr", CustomValidationType.NotValid.ToString(), "'{PropertyName}' geçerli değil.");
    AddTranslation("tr", CustomValidationType.NotExist.ToString(), "'{PropertyName}' bulunamadı.");
    AddTranslation("tr", CustomValidationType.CanNotBeUsed.ToString(), "'{PropertyName}' kullanılamaz.");
    AddTranslation("tr", CustomValidationType.CanNotContainSpace.ToString(), "'{PropertyName}' boşluk içeremez.");
    AddTranslation("tr", CustomValidationType.MustContainSpecialCharacter.ToString(),
                   "'{PropertyName}' en az 1 adet özel karakter bulunmalı.");
    AddTranslation("tr", CustomValidationType.MustContainDigit.ToString(),
                   "'{PropertyName}' en az 1 adet sayı bulunmalı.");
    AddTranslation("tr", CustomValidationType.MustContainLowerCase.ToString(),
                   "'{PropertyName}' en az 1 adet küçük harf bulunmalı.");
    AddTranslation("tr", CustomValidationType.MustContainUpperCase.ToString(),
                   "'{PropertyName}' en az 1 adet büyük harf bulunmalı.");
    AddTranslation("tr", CustomValidationType.Wrong.ToString(), "'{PropertyName}' yanlış.");
    AddTranslation("tr", CustomValidationType.InvalidAccount.ToString(), "Bu hesap geçersiz.");
    AddTranslation("tr", CustomValidationType.AccountCanNotBeUsed.ToString(), "Bu hesap kullanılamaz.");
    AddTranslation("tr", CustomValidationType.MustBeSame.ToString(), "{PropertyName} aynı olmalıdır.");
    AddTranslation("tr", CustomValidationType.CanNotBeSame.ToString(), "{PropertyName} aynı olamaz.");
  }
}