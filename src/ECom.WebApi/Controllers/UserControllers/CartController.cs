
using ECom.Domain.Entities;
using ECom.Domain.Extensions;

using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace ECom.WebApi.Controllers.UserControllers
{
    public class CartController : BaseUserController
    {
		private readonly ICartService _cartService;
		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}
		[HttpPost]
		public IActionResult AddOrIncreaseProduct(int productId)
		{
			if (HttpContext.IsUserAuthorized())
			{
				var user = HttpContext.GetUser();
				var res = _cartService.AddOrIncreaseProduct(user.Id, productId);
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
				var res = _cartService.RemoveOrDecreaseProduct(user.Id, productId);
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
				var res = _cartService.GetBasketProductCount(user.Id);
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
				var res = _cartService.ListBasketProducts(user.Id);
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
				var res = _cartService.Clear(user.Id);
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
