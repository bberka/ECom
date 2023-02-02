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

		public Result AddOrIncreaseProduct(AddOrIncreaseProductModel model)
		{
			UserMgr.This.CheckExists(model.UserId);
			ProductMgr.This.CheckExists(model.ProductId);
			var existing = GetFirstOrDefault(x => x.UserId == model.UserId && x.ProductId == model.ProductId);
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
					ProductId = model.ProductId,
					UserId = model.UserId,
					LastUpdateDate = DateTime.Now,
				};
				isSuccess = Add(newBasket);
			}
			if (!isSuccess)
			{
				return Result.Error(1, Response.DbErrorInternal);
			}
			return Result.Success(Response.Basket_AddOrIncreaseProduct_Success);
		}
		public Result RemoveOrDecreaseProduct(RemoveOrDecreaseProductModel model)
		{
			UserMgr.This.CheckExists(model.UserId);
			var exist = GetFirstOrDefault(x => x.UserId == model.UserId && x.ProductId == model.ProductId);
			if (exist is null)
			{
				return Result.Error(1, Response.Basket_ProductNotFound);
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
			return Result.Success(Response.Basket_AddOrIncreaseProduct_Success);
		}
		public int GetBasketProductCount(int userId)
		{
			UserMgr.This.CheckExists(userId);
			var count = Count(x => x.UserId == userId);
			return count;
		}
		public List<BasketProduct> ListBasketProducts(int userId)
		{
			UserMgr.This.CheckExists(userId);
			var list = Get(x => x.UserId == userId).ToList();
			return list ?? new();
		}
	}
}
