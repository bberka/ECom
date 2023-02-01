using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Constants
{
    public enum Response
    {
        Success,
        UnexpectedError,
        Exception,
        Fatal,
        Warning,

        DbErrorInternal,
		DbErrorForeignKeyIsInvalid,


        AccountIsNotValid,
        AccountDeleted,
        AccountDisabled,
        AdminDebugAccountCanNotBeUsed,

		InvalidUsername,
        InvalidPassword,
        WrongUsernameOrPassword,
        WrongUsername,
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
