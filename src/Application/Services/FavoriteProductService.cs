using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{
    public class FavoriteProductService : IFavoriteProductService
    {
        private readonly IEfEntityRepository<FavoriteProduct> _favoriteProductRepo;
        private readonly IProductService _productService;

        public FavoriteProductService(
            IEfEntityRepository<FavoriteProduct> favoriteProductRepo,
            IProductService productService)
        {
            this._favoriteProductRepo = favoriteProductRepo;
            this._productService = productService;
        }

        public Result AddProduct(int userId, int productId)
        {
            throw new NotImplementedException();
        }

        public Result RemoveProduct(int userId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
