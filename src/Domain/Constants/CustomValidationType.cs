using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Constants
{
	public enum CustomValidationType
	{
		ValidationError,
		Deleted,
		Disabled,
		Required,
		TooShort,
		TooLong,
		Expired,
		Invalid,
		AlreadyExists,
		AlreadyInUse,
		AlreadyDeleted,
		NotFound,
		NotVerified,
		NotValid,
		NotExist,
		CanNotBeUsed,
		CanNotContainSpace,
		MustContainSpecialCharacter,
		MustContainDigit,
		MustContainLowerCase,
		MustContainUpperCase,
		Wrong,
		InvalidAccount,
		AccountCanNotBeUsed,
		Null,
		CanNotBeSame,
		MustBeSame,
	}
}
