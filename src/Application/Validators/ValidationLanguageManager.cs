using FluentValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
	public class ValidationLanguageManager : LanguageManager
	{
		public ValidationLanguageManager()
		{
			AddTranslation("en", ErrCode.TooShort.ToString(), "'{PropertyName}' is too short.");
			AddTranslation("en", ErrCode.TooLong.ToString(), "'{PropertyName}' is too long.");
			AddTranslation("en", ErrCode.Expired.ToString(), "'{PropertyName}' is expired.");
			AddTranslation("en", ErrCode.AlreadyDeleted.ToString(), "'{PropertyName}' already deleted.");
			AddTranslation("en", ErrCode.AlreadyExists.ToString(), "'{PropertyName}' is already exist.");
			AddTranslation("en", ErrCode.AlreadyInUse.ToString(), "'{PropertyName}' is already in use.");
			AddTranslation("en", ErrCode.NotFound.ToString(), "'{PropertyName}' not found.");
			AddTranslation("en", ErrCode.NotVerified.ToString(), "'{PropertyName}' not verified.");
			AddTranslation("en", ErrCode.NotValid.ToString(), "'{PropertyName}' is invalid.");
			AddTranslation("en", ErrCode.NotExist.ToString(), "'{PropertyName}' does not exist.");
			AddTranslation("en", ErrCode.CanNotBeUsed.ToString(), "'{PropertyName}' can not be used.");
			AddTranslation("en", ErrCode.CanNotContainSpace.ToString(), "'{PropertyName}' can not contain space.");
			AddTranslation("en", ErrCode.MustContainSpecialCharacter.ToString(), "'{PropertyName}' must contain at least 1 special character.");
			AddTranslation("en", ErrCode.MustContainDigit.ToString(), "'{PropertyName}' must contain at least 1 digit.");
			AddTranslation("en", ErrCode.MustContainLowerCase.ToString(), "'{PropertyName}' must contain at least 1 lower case character.");
			AddTranslation("en", ErrCode.MustContainUpperCase.ToString(), "'{PropertyName}' must contain at least 1 upper case character.");
			AddTranslation("en", ErrCode.WrongData.ToString(), "'{PropertyName}' is wrong.");



			AddTranslation("tr", ErrCode.TooShort.ToString(), "'{PropertyName}' çok kısa.");
			AddTranslation("tr", ErrCode.TooLong.ToString(), "'{PropertyName}' çok uzun.");
			AddTranslation("tr", ErrCode.Expired.ToString(), "'{PropertyName}' süresi doldu.");
			AddTranslation("tr", ErrCode.AlreadyDeleted.ToString(), "'{PropertyName}' zaten silindi.");
			AddTranslation("tr", ErrCode.AlreadyExists.ToString(), "'{PropertyName}' zaten var.");
			AddTranslation("tr", ErrCode.AlreadyInUse.ToString(), "'{PropertyName}' zaten kullanılıyor.");
			AddTranslation("tr", ErrCode.NotFound.ToString(), "'{PropertyName}' bulunamadı.");
			AddTranslation("tr", ErrCode.NotVerified.ToString(), "'{PropertyName}' doğrulanması gerekli.");
			AddTranslation("tr", ErrCode.NotValid.ToString(), "'{PropertyName}' geçerli değil.");
			AddTranslation("tr", ErrCode.NotExist.ToString(), "'{PropertyName}' bulunamadı.");
			AddTranslation("tr", ErrCode.CanNotBeUsed.ToString(), "'{PropertyName}' kullanılamaz.");
			AddTranslation("tr", ErrCode.CanNotContainSpace.ToString(), "'{PropertyName}' boşluk içeremez.");
			AddTranslation("tr", ErrCode.MustContainSpecialCharacter.ToString(), "'{PropertyName}' en az 1 adet özel karakter bulunmalı.");
			AddTranslation("tr", ErrCode.MustContainDigit.ToString(), "'{PropertyName}' en az 1 adet sayı bulunmalı.");
			AddTranslation("tr", ErrCode.MustContainLowerCase.ToString(), "'{PropertyName}' en az 1 adet küçük harf bulunmalı.");
			AddTranslation("tr", ErrCode.MustContainUpperCase.ToString(), "'{PropertyName}' en az 1 adet büyük harf bulunmalı.");
			AddTranslation("tr", ErrCode.WrongData.ToString(), "'{PropertyName}' yanlış.");
		}
	}
}
