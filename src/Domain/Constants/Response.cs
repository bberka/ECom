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


		InvalidUsername,
        InvalidPassword,
        WrongUsername,
        WrongPassword,
        NotValid,
        EmailIsNotVerified,
        NotExist,
        
        NotAuthorized,
        SessionExpired,
        TokenExpired,
        //Basket 
        Basket_AddOrIncreaseProduct_Success,
        Basket_RemoveOrDecreaseProduct_Success,
        Basket_ProductNotFound,
    }
}
