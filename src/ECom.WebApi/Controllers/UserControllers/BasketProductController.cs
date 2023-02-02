using ECom.Domain.Entities;
using ECom.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    public class BasketProductController : BaseUserController
    {
		[HttpPost]
		public IActionResult AddOrIncreaseProduct(uint productId)
		{
			var userId = User.GetUserId();
			var res = BasketProductDal.This.AddOrIncreaseProduct(userId, productId);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", productId.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Info(productId.ToJsonString());
			return Ok(res);
		}

		[HttpPost]
		public IActionResult RemoveOrDecreaseProduct(uint productId)
		{
			var userId =User.GetUserId();
			var res = BasketProductDal.This.RemoveOrDecreaseProduct(userId,productId);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", productId);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(productId);
			return Ok(res);
		}

		[HttpGet]
		public IActionResult ProductCount()
		{
			var userId = User.GetUserId();
			var res = BasketProductDal.This.GetBasketProductCount(userId);
			return Ok(res);
		}
		[HttpGet]
		public IActionResult List()
		{
			var userId = User.GetUserId();
			var res = BasketProductDal.This.ListBasketProducts(userId);
			return Ok(res);
		}
		
	}
}
