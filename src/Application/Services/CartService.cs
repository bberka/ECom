using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace ECom.Application.Services
{
	public class CartService : ICartService
	{
		private readonly IEfEntityRepository<Cart> _cartRepo;
		private readonly IUserService _userService;
		private readonly IProductService _productService;
		public CartService(
			IEfEntityRepository<Cart> cartRepo,
			IUserService userService,
			IProductService productService)
		{
			this._cartRepo = cartRepo;
			this._userService = userService;
			this._productService = productService;
		}
		public Result AddOrIncreaseProduct(int userId, int productId)
		{
			_userService.CheckExistsOrThrow(userId);
			_productService.CheckExists(productId);
			var existing = _cartRepo.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			var isSuccess = false;
			if (existing != null)
			{
				existing.Count++;
				isSuccess = _cartRepo.Update(existing);
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
				isSuccess = _cartRepo.Add(newBasket);
			}
			if (!isSuccess)
			{
				return Result.Error(1, ErrCode.DbInternal);
			}
			return Result.Success(ErrCode.Success,nameof(AddOrIncreaseProduct));
		}
		public Result RemoveOrDecreaseProduct(int userId, int productId)
		{
			var exist = _cartRepo.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			if (exist is null)
			{
				throw new NotFoundException(nameof(Product));
			}
			var isSuccess = false;
			if (exist.Count > 1)
			{
				exist.Count--;
				isSuccess = _cartRepo.Update(exist);
			}
			else
			{
				isSuccess = _cartRepo.Delete(exist);
			}
			if (!isSuccess) throw new DbInternalException(nameof(RemoveOrDecreaseProduct));
			return Result.Success(nameof(RemoveOrDecreaseProduct));
		}
		public int GetBasketProductCount(int userId)
		{
			var count = _cartRepo.Count(x => x.UserId == userId);
			return count;
		}
		public List<Cart> ListBasketProducts(int userId)
		{
			var list = _cartRepo.Get(x => x.UserId == userId).ToList();
			return list ?? new();
		}

		public Result Clear(int userId)
		{
			var res = _cartRepo.DeleteWhere(x => x.UserId == userId);
            if (res == 0) throw new DbInternalException(nameof(Clear));
			return Result.Success("Deleted");
		}
	}
}
