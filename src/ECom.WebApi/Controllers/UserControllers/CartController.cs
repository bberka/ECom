
using ECom.Domain.Entities;
using ECom.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace ECom.WebApi.Controllers.UserControllers
{
    [AllowAnonymous]
    public class CartController : BaseUserController
    {
		private readonly ICartService _cartService;
		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}

		[HttpPost]
		public ActionResult<Result> AddOrIncreaseProduct(int productId)
		{
			if (HttpContext.IsUserAuthenticated())
			{
				var user = HttpContext.GetUser();
				var res = _cartService.AddOrIncreaseProduct(user.Id, productId);
				logger.Info(productId.ToJsonString());
				return res;
			}
			else
			{
				HttpContext.AddOrIncreaseInCart(productId);
				return Result.Success();
			}
		}

		[HttpPost]
		public ActionResult<Result> RemoveOrDecreaseProduct(int productId)
		{

			if (HttpContext.IsUserAuthenticated())
			{
				var user = HttpContext.GetUser();
				var res = _cartService.RemoveOrDecreaseProduct(user.Id, productId);
				logger.Info(productId);
				return res;

			}
			else
			{
				HttpContext.RemoveOrDecreaseInCart(productId);
				return Result.Success();
			}
			
		}

		[HttpGet]
		public ActionResult<int> ProductCount()
		{
			if (HttpContext.IsUserAuthenticated())
			{
				var user = HttpContext.GetUser();
				return _cartService.GetBasketProductCount(user.Id);
			}
			else
			{
				return HttpContext.GetCart().Count;
			}
			
		}
		[HttpGet]
		public ActionResult<List<Cart>> List()
		{
			if (HttpContext.IsUserAuthenticated())
			{
				var userId = HttpContext.GetUserId();
				return _cartService.ListBasketProducts(userId);
			}
			else
			{
				return HttpContext.GetDbCartEntity(-1).ToList();
			}
			
		}
		[HttpPost]
		public ActionResult<Result> Clear()
		{

			if (HttpContext.IsUserAuthenticated())
			{
				var user = HttpContext.GetUser();
				var res = _cartService.Clear(user.Id);
				logger.Info();
				return res;

			}
			else
			{
				HttpContext.ClearCart();
				return Result.Success();
			}

		}

	}
}
