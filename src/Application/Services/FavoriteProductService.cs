using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Domain.Results;

namespace ECom.Application.Services
{
    public class FavoriteProductService : IFavoriteProductService
    {
        private readonly IEfEntityRepository<FavoriteProduct> _favoriteProductRepo;
        private readonly IEfEntityRepository<Product> _productRepo;
        private readonly IEfEntityRepository<ProductDetail> _productDetailRepo;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public FavoriteProductService(
            IEfEntityRepository<FavoriteProduct> favoriteProductRepo,
            IEfEntityRepository<Product> productRepo,
            IEfEntityRepository<ProductDetail> productDetailRepo,
            IProductService productService,
            IUserService userService)
        {
            this._favoriteProductRepo = favoriteProductRepo;
            this._productRepo = productRepo;
            this._productDetailRepo = productDetailRepo;
            this._productService = productService;
            this._userService = userService;
        }

        public Result AddProduct(int userId, int productId)
        {
            var userExist = _userService.Exists(userId);
            if (!userExist)
            {
                return DomainResult.User.NotFoundResult(1);
            }
            var productExist = _productService.Exists(productId);
            if(!productExist)
            {
                return DomainResult.Product.NotFoundResult(2);
            }
            var data = new FavoriteProduct
            {
                RegisterDate = DateTime.Now,
                ProductId = productId,
                UserId = userId,
            };
            var res =_favoriteProductRepo.Add(data);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(3);
            }
            return DomainResult.FavoriteProduct.AddSuccessResult();
        }

        public Result RemoveProduct(int userId, int productId)
        {
            var userExist = _userService.Exists(userId);
            if (!userExist)
            {
                return DomainResult.User.NotFoundResult(1);
            }
            var favProduct = _favoriteProductRepo.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
            if(favProduct is null)
            {
                return DomainResult.FavoriteProduct.NotFoundResult(2);
            }
            var res = _favoriteProductRepo.Delete(favProduct);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(3);
            }

            return DomainResult.FavoriteProduct.RemoveSuccessResult();
        }

        public List<ProductDTO> GetFavoriteProducts(int userId,string culture)
        {
            var favList = _favoriteProductRepo
                .Get(x => x.UserId == userId)
                .Select(x => x.ProductId)
                .ToArray();
            var products = _productRepo
                .Get(x => !favList.Contains(x.Id))
                .Include(x => x.Variant)
                .ToList();
            var productDetails = _productDetailRepo
                .Get(x => !products.Any(y => y.Id == x.ProductId) && x.Culture == culture)
                .ToList();
            var res = new List<ProductDTO>();
            foreach(var product in products)
            {
                var data = new ProductDTO();
                data.Product = product;
                data.Details = productDetails.FirstOrDefault(x=> x.ProductId == product.Id);
                res.Add(data);
            }
            return res;
        }
    }
}
