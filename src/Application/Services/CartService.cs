using ECom.Domain.Results;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace ECom.Application.Services
{
	public class CartService : ICartService
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
		private readonly IProductService _productService;
		public CartService(
			IUnitOfWork unitOfWork,
			IUserService userService,
			IProductService productService)
		{
            _unitOfWork = unitOfWork;
            this._userService = userService;
			this._productService = productService;
		}
		public Result AddOrIncreaseProduct(int userId, int productId)
		{
			var userExist = _userService.Exists(userId);
            if (!userExist)
            {
                return DomainResult.User.NotFoundResult(1);
            }
            var productExist = _productService.Exists(productId);
			if (!productExist)
            {
                return DomainResult.Product.NotFoundResult(2);
			}
			var existing = _unitOfWork.CartRepository.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			if (existing != null)
			{
				existing.Count++;
				_unitOfWork.CartRepository.Update(existing);
                
            }
			else
			{
				var newBasket = new Cart
				{
					Count = 1,
					RegisterDate = DateTime.Now,
					ProductId = (int)productId,
					UserId = (int)userId,
					LastUpdateDate = DateTime.Now,
				};
				_unitOfWork.CartRepository.Insert(newBasket);
                
            }
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(3);
            }

            return DomainResult.Cart.AddProductSuccessResult();
		}
		public Result RemoveOrDecreaseProduct(int userId, int productId)
		{
			var exist = _unitOfWork.CartRepository.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			if (exist is null)
            {
                return DomainResult.Cart.NotFoundResult(1);
			}
			if (exist.Count > 1)
			{
				exist.Count--;
				_unitOfWork.CartRepository.Update(exist);
            }
			else
			{
				_unitOfWork.CartRepository.Delete(exist);
                
            }

            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }

            return DomainResult.Cart.RemoveProductSuccessResult();
		}
		public int GetBasketProductCount(int userId)
		{
			return _unitOfWork.CartRepository.Count(x => x.UserId == userId);
		}
		public List<Cart> ListBasketProducts(int userId)
		{
			return _unitOfWork.CartRepository.Get(x => x.UserId == userId).ToList();
		}

		public Result Clear(int userId)
		{

			var list = _unitOfWork.CartRepository.Get(x => x.UserId == userId);
            _unitOfWork.CartRepository.DeleteRange(list);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.Cart.ClearSuccessResult();
		}
	}
}
