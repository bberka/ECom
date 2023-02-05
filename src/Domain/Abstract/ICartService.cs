using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface ICartService
    {
        Result AddOrIncreaseProduct(int userId, int productId);
        int GetBasketProductCount(int userId);
        List<Cart> ListBasketProducts(int userId);
        Result RemoveOrDecreaseProduct(int userId, int productId);
        Result Clear(int userId);
    }
}
