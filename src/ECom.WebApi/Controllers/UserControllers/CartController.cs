using ECom.Domain.Entities;
using ECom.Domain.Extensions;

using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace ECom.WebApi.Controllers.UserControllers
{
    public class CartController : BaseUserController
    {
		private readonly ICartService _service;
		public CartController(ICartService service)
		{
			_service = service;
		}
		[HttpPost]
		public IActionResult AddOrIncreaseProduct(uint productId)
		{
			var res = _service.AddOrIncreaseProduct(UserId, productId);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, res.ErrorCode, res.Parameters, productId.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Info(productId.ToJsonString());
			return Ok(res);
		}

		[HttpPost]
		public IActionResult RemoveOrDecreaseProduct(uint productId)
		{
			var res = _service.RemoveOrDecreaseProduct(UserId,productId);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, res.ErrorCode, res.Parameters, productId);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(productId);
			return Ok(res);
		}

		[HttpGet]
		public IActionResult ProductCount()
		{
			var res = _service.GetBasketProductCount(UserId);
			return Ok(res);
		}
		[HttpGet]
		public IActionResult List()
		{
			var res = _service.ListBasketProducts(UserId);
			return Ok(res);
		}
		
	}
}
