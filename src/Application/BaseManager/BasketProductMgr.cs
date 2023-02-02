using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace ECom.Application.BaseManager
{
	public class BasketProductMgr : EfEntityRepositoryBase<BasketProduct, EComDbContext>
	{

		private BasketProductMgr() { }
		public static BasketProductMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static BasketProductMgr? Instance;

		public Result AddOrIncreaseProduct(uint userId, uint productId)
		{
			UserMgr.This.CheckExists(userId);
			ProductMgr.This.CheckExists(productId);
			var existing = GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			var isSuccess = false;
			if (existing != null)
			{
				existing.Count++;
				isSuccess = Update(existing);
			}
			else
			{
				var newBasket = new BasketProduct
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
			return Result.Success(Response.BasketAddOrIncreaseProduct_Success);
		}
		public Result RemoveOrDecreaseProduct(uint userId,uint productId)
		{
			UserMgr.This.CheckExists(userId);
			var exist = GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			if (exist is null)
			{
				return Result.Error(1, Response.BasketProductNotFound);
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
			return Result.Success(Response.BasketAddOrIncreaseProduct_Success);
		}
		public int GetBasketProductCount(uint userId)
		{
			UserMgr.This.CheckExists(userId);
			var count = Count(x => x.UserId == userId);
			return count;
		}
		public List<BasketProduct> ListBasketProducts(uint userId)
		{
			UserMgr.This.CheckExists(userId);
			var list = Get(x => x.UserId == userId).ToList();
			return list ?? new();
		}
	}
}
