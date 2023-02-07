using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Domain.Results;
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
                return DomainResult.User.NotFoundResult(1);
            }
            var productExist = _productService.Exists(productId);
			if (!productExist)
            {
                return DomainResult.Product.NotFoundResult(2);
			}
			var existing = _cartRepo.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			if (existing != null)
			{
				existing.Count++;
				var updateResult = _cartRepo.Update(existing);
                if (!updateResult)
                {
                    return DomainResult.DbInternalErrorResult(3);
                }
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
				var addResult = _cartRepo.Add(newBasket);
                if (!addResult)
                {
                    return DomainResult.DbInternalErrorResult(4);
                }
            }
			return DomainResult.Cart.AddProductSuccessResult();
		}
		public Result RemoveOrDecreaseProduct(int userId, int productId)
		{
			var exist = _cartRepo.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
			if (exist is null)
            {
                return DomainResult.Cart.NotFoundResult(1);
			}
			if (exist.Count > 1)
			{
				exist.Count--;
				var updateResult = _cartRepo.Update(exist);
                if (!updateResult)
                {
                    return DomainResult.DbInternalErrorResult(2);
                }
            }
			else
			{
				var deleteResult = _cartRepo.Delete(exist);
                if (!deleteResult)
                {
                    return DomainResult.DbInternalErrorResult(3);
                }
            }
		    return DomainResult.Cart.RemoveProductSuccessResult();
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
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.Cart.ClearSuccessResult();
		}
	}
}
