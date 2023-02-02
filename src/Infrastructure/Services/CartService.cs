using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace ECom.Infrastructure.Services
{
	public interface ICartService : IEfEntityRepository<Cart>
	{
		Result AddOrIncreaseProduct(uint userId, uint productId);
		int GetBasketProductCount(uint userId);
		List<Cart> ListBasketProducts(uint userId);
		Result RemoveOrDecreaseProduct(uint userId, uint productId);
	}

	public class CartService : EfEntityRepositoryBase<Cart, EComDbContext>, ICartService
	{
		public Result AddOrIncreaseProduct(uint userId, uint productId)
		{
			//UserDal.This.CheckExists(userId);
			//ProductService.This.CheckExists(productId);
			var existing = GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			var isSuccess = false;
			if (existing != null)
			{
				existing.Count++;
				isSuccess = Update(existing);
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
				isSuccess = Add(newBasket);
			}
			if (!isSuccess)
			{
				return Result.Error(1, Response.DbErrorInternal);
			}
			return Result.Success(Response.CartAddOrIncreaseProductSuccess);
		}
		public Result RemoveOrDecreaseProduct(uint userId, uint productId)
		{
			var exist = GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			if (exist is null)
			{
				return Result.Error(1, Response.CartProductNotFound);
			}
			var isSuccess = false;
			if (exist.Count > 1)
			{
				exist.Count--;
				isSuccess = Update(exist);
			}
			else
			{
				isSuccess = Delete(exist);
			}
			if (!isSuccess)
			{
				return Result.Error(1, Response.DbErrorInternal);
			}
			return Result.Success(Response.CartRemoveOrDecreaseProductSuccess);
		}
		public int GetBasketProductCount(uint userId)
		{
			var count = Count(x => x.UserId == userId);
			return count;
		}
		public List<Cart> ListBasketProducts(uint userId)
		{
			var list = Get(x => x.UserId == userId).ToList();
			return list ?? new();
		}

	}
}
