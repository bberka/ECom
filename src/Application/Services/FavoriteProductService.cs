using ECom.Domain.Results;

namespace ECom.Application.Services
{
    public class FavoriteProductService : IFavoriteProductService
    {
        private readonly IEfEntityRepository<FavoriteProduct> _favoriteProductRepo;
        private readonly IEfEntityRepository<Product> _productRepo;
        private readonly IEfEntityRepository<ProductDetail> _productDetailRepo;
        private readonly IEfEntityRepository<ProductImage> _productImageRepo;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public FavoriteProductService(
            IEfEntityRepository<FavoriteProduct> favoriteProductRepo,
            IEfEntityRepository<Product> productRepo,
            IEfEntityRepository<ProductDetail> productDetailRepo,
            IProductService productService,
            IUserService userService, 
            IEfEntityRepository<ProductImage> productImageRepo)
        {
            this._favoriteProductRepo = favoriteProductRepo;
            this._productRepo = productRepo;
            this._productDetailRepo = productDetailRepo;
            this._productService = productService;
            this._userService = userService;
            _productImageRepo = productImageRepo;
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

        public List<FavoriteProduct> GetFavoriteProducts(int userId, ushort page, string culture = ConstantMgr.DefaultCulture)
        {
            return _favoriteProductRepo
                .Get(x => x.UserId == userId)
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductImages)
                .ToList();
           
        }
    }
}
