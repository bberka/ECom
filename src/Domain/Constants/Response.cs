using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public enum Response
    {
        Success,
        UnexpectedError,
        Exception,
        Fatal,
        Warning,
        InternalDbError,

        User_InvalidUsername,
        User_InvalidPassword,
        User_WrongUsername,
        User_WrongPassword,
        User_NotValid,
        User_EmailIsNotVerified,
        User_NotExist,
        
        //Basket 
        Basket_AddOrIncreaseProduct_Success,
        Basket_RemoveOrDecreaseProduct_Success,
        Basket_ProductNotFound,
    }
}
