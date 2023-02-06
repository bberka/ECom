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
			var userExist = _userService.Exists(userId);
            if (!userExist)
            {
                return Result.Warn(1, ErrorCode.NotFound, nameof(User));
            }
            var productExist = _productService.Exists(productId);
			if (!productExist)
			{
				return Result.Warn(2, ErrorCode.NotFound, nameof(Product));
			}
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
				return Result.DbInternal(3);
			}
			return Result.Success();
		}
		public Result RemoveOrDecreaseProduct(int userId, int productId)
		{
			var exist = _cartRepo.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			if (exist is null)
			{
				return Result.Warn(1, ErrorCode.NotFound,nameof(Cart));
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
                return Result.DbInternal(2);
            }
            return Result.Success();
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
            if (res == 0) 
			{
                return Result.DbInternal(2);
            }
			return Result.Success("Deleted");
		}
	}
}
