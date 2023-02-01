using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Constants
{
    public enum Response
    {

		None,
		Success,
        UnexpectedError,
        Exception,
        Fatal,
        Warning,

        DbErrorInternal,
		DbErrorForeignKeyIsInvalid,


        AccountIsNotValid,
        AccountIsDeleted,
        AccountDisabled,
        DebugAccountCanNotBeUsed,

        PasswordRequired,
        PasswordTooShort,
        PasswordTooLong,
        InvalidEmailAddress,
        EmailIsInUse,
        PasswordCanNotContainSpace,
        PasswordMustContainSpecialCharacter,
        PasswordMustContainNumber,
		PasswordMustContainLowerCase,
		PasswordMustContainUpperCase,


        AccountNotFound,
        WrongPassword,
        NotValid,
        EmailIsNotVerified,
        UserNotExist,
        
        NotAuthorized,
        SessionExpired,
        TokenExpired,
        //Basket 
        Basket_AddOrIncreaseProduct_Success,
        Basket_RemoveOrDecreaseProduct_Success,
        Basket_ProductNotFound,
    }
}
