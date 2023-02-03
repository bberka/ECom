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
	public interface ICartService
	{
		Result AddOrIncreaseProduct(int userId, uint productId);
		int GetBasketProductCount(int userId);
		List<Cart> ListBasketProducts(int userId);
		Result RemoveOrDecreaseProduct(int userId, uint productId);
	}

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
		public Result AddOrIncreaseProduct(int userId, uint productId)
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
					LastNotFoundate = DateTime.Now,
				};
				isSuccess = _cartRepo.Add(newBasket);
			}
			if (!isSuccess)
			{
				return Result.Error(1, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.Success,nameof(AddOrIncreaseProduct));
		}
		public Result RemoveOrDecreaseProduct(int userId, uint productId)
		{
			var exist = _cartRepo.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			if (exist is null)
			{
				return Result.Error(1, ErrCode.NotFound ,"Product");
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
			if (!isSuccess)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
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

	}
}
