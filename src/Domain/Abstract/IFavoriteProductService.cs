using ECom.Domain.ApiModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IFavoriteProductService
    {
        Result AddProduct(int userId, int productId);
        Result RemoveProduct(int userId, int productId);
        List<ProductDTO> GetFavoriteProducts(int userId,string culture);
    }
}
