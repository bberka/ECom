using ECom.Domain.Results;

namespace ECom.Application.Services
{
    public class FavoriteProductService : IFavoriteProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public FavoriteProductService(
            IUnitOfWork unitOfWork,
            IProductService productService,
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
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
            _unitOfWork.FavoriteProductRepository.Add(data);
            var res = _unitOfWork.Save();
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
            var favProduct = _unitOfWork.FavoriteProductRepository.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
            if(favProduct is null)
            {
                return DomainResult.FavoriteProduct.NotFoundResult(2);
            }
            _unitOfWork.FavoriteProductRepository.Delete(favProduct);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(3);
            }

            return DomainResult.FavoriteProduct.RemoveSuccessResult();
        }

        public List<FavoriteProduct> GetFavoriteProducts(int userId, ushort page, string culture = ConstantMgr.DefaultCulture)
        {
            return _unitOfWork.FavoriteProductRepository
                .Get(x => x.UserId == userId)
                .Include(x => x.Product)
                .ThenInclude(x => x.Images)
                .ToList();
           
        }
    }
}
