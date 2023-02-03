using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Constants
{
    public enum ErrCode
    {

		None,
		Success,
        UnexpectedError,
        Exception,
        Fatal,
		Error,
        Warning,
		DbErrorInternal,
		ValidationError,
		NullReference,
		Deleted,
		Disabled,
        Required,
        TooShort,
        TooLong,
        Expired,

		AlreadyExists,
		AlreadyInUse,
		AlreadyDeleted,

		NotFound,
		NotVerified,
		NotValid,
		NotExist,
		NotAuthorized,

		CanNotBeUsed,
		CanNotContainSpace,

        MustContainSpecialCharacter,
        MustContainDigit,
		MustContainLowerCase,
		MustContainUpperCase,

        WrongData,
		Invalid,
	}
}
