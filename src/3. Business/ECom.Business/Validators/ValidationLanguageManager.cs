using FluentValidation.Resources;

namespace ECom.Business.Validators;

public class ValidationLanguageManager : LanguageManager
{
  public ValidationLanguageManager() {
    AddTranslation("English", CustomValidationType.TooShort.ToString(), "'{PropertyName}' is too short.");
    AddTranslation("English", CustomValidationType.TooLong.ToString(), "'{PropertyName}' is too long.");
    AddTranslation("English", CustomValidationType.Expired.ToString(), "'{PropertyName}' is expired.");
    AddTranslation("English", CustomValidationType.AlreadyDeleted.ToString(), "'{PropertyName}' already deleted.");
    AddTranslation("English", CustomValidationType.AlreadyExists.ToString(), "'{PropertyName}' is already exist.");
    AddTranslation("English", CustomValidationType.AlreadyInUse.ToString(), "'{PropertyName}' is already in use.");
    AddTranslation("English", CustomValidationType.NotFound.ToString(), "'{PropertyName}' is not found.");
    AddTranslation("English", CustomValidationType.NotVerified.ToString(), "'{PropertyName}' is not verified.");
    AddTranslation("English", CustomValidationType.NotValid.ToString(), "'{PropertyName}' is invalid.");
    AddTranslation("English", CustomValidationType.NotExist.ToString(), "'{PropertyName}' does not exist.");
    AddTranslation("English", CustomValidationType.CanNotBeUsed.ToString(), "'{PropertyName}' can not be used.");
    AddTranslation("English", CustomValidationType.CanNotContainSpace.ToString(), "'{PropertyName}' can not contain space.");
    AddTranslation("English", CustomValidationType.MustContainSpecialCharacter.ToString(),
                   "'{PropertyName}' must contain at least 1 special character.");
    AddTranslation("English", CustomValidationType.MustContainDigit.ToString(),
                   "'{PropertyName}' must contain at least 1 digit.");
    AddTranslation("English", CustomValidationType.MustContainLowerCase.ToString(),
                   "'{PropertyName}' must contain at least 1 lower case character.");
    AddTranslation("English", CustomValidationType.MustContainUpperCase.ToString(),
                   "'{PropertyName}' must contain at least 1 upper case character.");
    AddTranslation("English", CustomValidationType.Wrong.ToString(), "'{PropertyName}' is wrong.");
    AddTranslation("English", CustomValidationType.InvalidAccount.ToString(), "Account is invalid.");
    AddTranslation("English", CustomValidationType.AccountCanNotBeUsed.ToString(), "This account can not be used.");
    AddTranslation("English", CustomValidationType.MustBeSame.ToString(), "{PropertyName} must be same.");
    AddTranslation("English", CustomValidationType.CanNotBeSame.ToString(), "{PropertyName} can not be same.");

    AddTranslation("Turkish", CustomValidationType.TooShort.ToString(), "'{PropertyName}' çok kısa.");
    AddTranslation("Turkish", CustomValidationType.TooLong.ToString(), "'{PropertyName}' çok uzun.");
    AddTranslation("Turkish", CustomValidationType.Expired.ToString(), "'{PropertyName}' süresi doldu.");
    AddTranslation("Turkish", CustomValidationType.AlreadyDeleted.ToString(), "'{PropertyName}' zaten silindi.");
    AddTranslation("Turkish", CustomValidationType.AlreadyExists.ToString(), "'{PropertyName}' zaten var.");
    AddTranslation("Turkish", CustomValidationType.AlreadyInUse.ToString(), "'{PropertyName}' zaten kullanılıyor.");
    AddTranslation("Turkish", CustomValidationType.NotFound.ToString(), "'{PropertyName}' bulunamadı.");
    AddTranslation("Turkish", CustomValidationType.NotVerified.ToString(), "'{PropertyName}' doğrulanması gerekli.");
    AddTranslation("Turkish", CustomValidationType.NotValid.ToString(), "'{PropertyName}' geçerli değil.");
    AddTranslation("Turkish", CustomValidationType.NotExist.ToString(), "'{PropertyName}' bulunamadı.");
    AddTranslation("Turkish", CustomValidationType.CanNotBeUsed.ToString(), "'{PropertyName}' kullanılamaz.");
    AddTranslation("Turkish", CustomValidationType.CanNotContainSpace.ToString(), "'{PropertyName}' boşluk içeremez.");
    AddTranslation("Turkish", CustomValidationType.MustContainSpecialCharacter.ToString(),
                   "'{PropertyName}' English az 1 adet özel karakter bulunmalı.");
    AddTranslation("Turkish", CustomValidationType.MustContainDigit.ToString(),
                   "'{PropertyName}' English az 1 adet sayı bulunmalı.");
    AddTranslation("Turkish", CustomValidationType.MustContainLowerCase.ToString(),
                   "'{PropertyName}' English az 1 adet küçük harf bulunmalı.");
    AddTranslation("Turkish", CustomValidationType.MustContainUpperCase.ToString(),
                   "'{PropertyName}' English az 1 adet büyük harf bulunmalı.");
    AddTranslation("Turkish", CustomValidationType.Wrong.ToString(), "'{PropertyName}' yanlış.");
    AddTranslation("Turkish", CustomValidationType.InvalidAccount.ToString(), "Bu hesap geçersiz.");
    AddTranslation("Turkish", CustomValidationType.AccountCanNotBeUsed.ToString(), "Bu hesap kullanılamaz.");
    AddTranslation("Turkish", CustomValidationType.MustBeSame.ToString(), "{PropertyName} aynı olmalıdır.");
    AddTranslation("Turkish", CustomValidationType.CanNotBeSame.ToString(), "{PropertyName} aynı olamaz.");
  }
}