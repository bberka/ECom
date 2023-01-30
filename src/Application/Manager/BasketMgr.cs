using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager
{
    public static class BasketMgr
    {
        public static Result AddProductToBasket(long userNo,long productNo,long count)
        {
            

            ThrowHelper.NotImplemented();
            Result result = new();
            return result;
        }
    }
}
