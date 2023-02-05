
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
		public IActionResult AddOrIncreaseProduct(int productId)
		{
			if (HttpContext.IsUserAuthorized())
			{
				var user = HttpContext.GetUser();
				var res = _service.AddOrIncreaseProduct(user.Id, productId);
				if (!res.IsSuccess)
				{
					logger.Warn(res.Rv, res.ErrorCode, res.Parameters, productId.ToJsonString());
					return BadRequest(res);
				}
				logger.Info(productId.ToJsonString());
				return Ok(res);
			}
			else
			{
				HttpContext.AddOrIncreaseInCart(productId);
				return Ok(Result.Success());
			}
		}

		[HttpPost]
		public IActionResult RemoveOrDecreaseProduct(int productId)
		{

			if (HttpContext.IsUserAuthorized())
			{
				var user = HttpContext.GetUser();
				var res = _service.RemoveOrDecreaseProduct(user.Id, productId);
				if (!res.IsSuccess)
				{
					logger.Warn(res.Rv, res.ErrorCode, res.Parameters, productId);
					return BadRequest(res.ToJsonString());
				}
				logger.Info(productId);
				return Ok(res);

			}
			else
			{
				HttpContext.RemoveOrDecreaseInCart(productId);
				return Ok(Result.Success());
			}
			
		}

		[HttpGet]
		public IActionResult ProductCount()
		{
			if (HttpContext.IsUserAuthorized())
			{
				var user = HttpContext.GetUser();
				var res = _service.GetBasketProductCount(user.Id);
				return Ok(res);
			}
			else
			{
				return Ok(HttpContext.GetCart().Count);
			}
			
		}
		[HttpGet]
		public IActionResult List()
		{
			if (HttpContext.IsUserAuthorized())
			{
				var user = HttpContext.GetUser();
				var res = _service.ListBasketProducts(user.Id);
				return Ok(res);
			}
			else
			{
				var res = HttpContext.GetDbCartEntity(-1).ToList();
				return Ok(res);
			}
			
		}
		[HttpPost]
		public IActionResult Clear()
		{

			if (HttpContext.IsUserAuthorized())
			{
				var user = HttpContext.GetUser();
				var res = _service.Clear(user.Id);
				if (!res.IsSuccess)
				{
					logger.Warn(res.Rv, res.ErrorCode, res.Parameters);
					return BadRequest(res.ToJsonString());
				}
				logger.Info();
				return Ok(res);

			}
			else
			{
				HttpContext.ClearCart();
				return Ok(Result.Success());
			}

		}

	}
}
