using ECom.Foundation.Static;
using FluentValidation.Resources;

namespace ECom.Business.Validators;

public class ValidationLanguageManager : LanguageManager
{
  public ValidationLanguageManager() {
    AddTranslation("en_us", CustomValidationType.TooShort.ToString(), "'{PropertyName}' is too short.");
    AddTranslation("en_us", CustomValidationType.TooLong.ToString(), "'{PropertyName}' is too long.");
    AddTranslation("en_us", CustomValidationType.Expired.ToString(), "'{PropertyName}' is expired.");
    AddTranslation("en_us", CustomValidationType.AlreadyDeleted.ToString(), "'{PropertyName}' already deleted.");
    AddTranslation("en_us", CustomValidationType.AlreadyExists.ToString(), "'{PropertyName}' is already exist.");
    AddTranslation("en_us", CustomValidationType.AlreadyInUse.ToString(), "'{PropertyName}' is already in use.");
    AddTranslation("en_us", CustomValidationType.NotFound.ToString(), "'{PropertyName}' is not found.");
    AddTranslation("en_us", CustomValidationType.NotVerified.ToString(), "'{PropertyName}' is not verified.");
    AddTranslation("en_us", CustomValidationType.NotValid.ToString(), "'{PropertyName}' is invalid.");
    AddTranslation("en_us", CustomValidationType.NotExist.ToString(), "'{PropertyName}' does not exist.");
    AddTranslation("en_us", CustomValidationType.CanNotBeUsed.ToString(), "'{PropertyName}' can not be used.");
    AddTranslation("en_us", CustomValidationType.CanNotContainSpace.ToString(), "'{PropertyName}' can not contain space.");
    AddTranslation("en_us",
                   CustomValidationType.MustContainSpecialCharacter.ToString(),
                   "'{PropertyName}' must contain at least 1 special character.");
    AddTranslation("en_us",
                   CustomValidationType.MustContainDigit.ToString(),
                   "'{PropertyName}' must contain at least 1 digit.");
    AddTranslation("en_us",
                   CustomValidationType.MustContainLowerCase.ToString(),
                   "'{PropertyName}' must contain at least 1 lower case character.");
    AddTranslation("en_us",
                   CustomValidationType.MustContainUpperCase.ToString(),
                   "'{PropertyName}' must contain at least 1 upper case character.");
    AddTranslation("en_us", CustomValidationType.Wrong.ToString(), "'{PropertyName}' is wrong.");
    AddTranslation("en_us", CustomValidationType.InvalidAccount.ToString(), "Account is invalid.");
    AddTranslation("en_us", CustomValidationType.AccountCanNotBeUsed.ToString(), "This account can not be used.");
    AddTranslation("en_us", CustomValidationType.MustBeSame.ToString(), "{PropertyName} must be same.");
    AddTranslation("en_us", CustomValidationType.CanNotBeSame.ToString(), "{PropertyName} can not be same.");

    AddTranslation("tr_tr", CustomValidationType.TooShort.ToString(), "'{PropertyName}' çok kısa.");
    AddTranslation("tr_tr", CustomValidationType.TooLong.ToString(), "'{PropertyName}' çok uzun.");
    AddTranslation("tr_tr", CustomValidationType.Expired.ToString(), "'{PropertyName}' süresi doldu.");
    AddTranslation("tr_tr", CustomValidationType.AlreadyDeleted.ToString(), "'{PropertyName}' zaten silindi.");
    AddTranslation("tr_tr", CustomValidationType.AlreadyExists.ToString(), "'{PropertyName}' zaten var.");
    AddTranslation("tr_tr", CustomValidationType.AlreadyInUse.ToString(), "'{PropertyName}' zaten kullanılıyor.");
    AddTranslation("tr_tr", CustomValidationType.NotFound.ToString(), "'{PropertyName}' bulunamadı.");
    AddTranslation("tr_tr", CustomValidationType.NotVerified.ToString(), "'{PropertyName}' doğrulanması gerekli.");
    AddTranslation("tr_tr", CustomValidationType.NotValid.ToString(), "'{PropertyName}' geçerli değil.");
    AddTranslation("tr_tr", CustomValidationType.NotExist.ToString(), "'{PropertyName}' bulunamadı.");
    AddTranslation("tr_tr", CustomValidationType.CanNotBeUsed.ToString(), "'{PropertyName}' kullanılamaz.");
    AddTranslation("tr_tr", CustomValidationType.CanNotContainSpace.ToString(), "'{PropertyName}' boşluk içeremez.");
    AddTranslation("tr_tr",
                   CustomValidationType.MustContainSpecialCharacter.ToString(),
                   "'{PropertyName}' en_us az 1 adet özel karakter bulunmalı.");
    AddTranslation("tr_tr",
                   CustomValidationType.MustContainDigit.ToString(),
                   "'{PropertyName}' en_us az 1 adet sayı bulunmalı.");
    AddTranslation("tr_tr",
                   CustomValidationType.MustContainLowerCase.ToString(),
                   "'{PropertyName}' en_us az 1 adet küçük harf bulunmalı.");
    AddTranslation("tr_tr",
                   CustomValidationType.MustContainUpperCase.ToString(),
                   "'{PropertyName}' en_us az 1 adet büyük harf bulunmalı.");
    AddTranslation("tr_tr", CustomValidationType.Wrong.ToString(), "'{PropertyName}' yanlış.");
    AddTranslation("tr_tr", CustomValidationType.InvalidAccount.ToString(), "Bu hesap geçersiz.");
    AddTranslation("tr_tr", CustomValidationType.AccountCanNotBeUsed.ToString(), "Bu hesap kullanılamaz.");
    AddTranslation("tr_tr", CustomValidationType.MustBeSame.ToString(), "{PropertyName} aynı olmalıdır.");
    AddTranslation("tr_tr", CustomValidationType.CanNotBeSame.ToString(), "{PropertyName} aynı olamaz.");
  }
}