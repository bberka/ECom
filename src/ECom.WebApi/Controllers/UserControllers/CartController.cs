
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
        private readonly ILogService _logService;

        public CartController(ICartService cartService, ILogService logService)
        {
            _cartService = cartService;
            _logService = logService;
        }

		[HttpPost]
		public ActionResult<Result> AddOrIncreaseProduct(int productId)
        {
            if (HttpContext.IsUserAuthenticated())
			{
				var userId = HttpContext.GetUserId();
				var res = _cartService.AddOrIncreaseProduct(userId, productId);
				_logService.UserLog(res,userId, "Cart.AddOrIncreaseProduct",productId);
				return res;
			}
            HttpContext.AddOrIncreaseInCart(productId);
            return Result.Success();
        }

		[HttpPost]
		public ActionResult<Result> RemoveOrDecreaseProduct(int productId)
        {

            if (HttpContext.IsUserAuthenticated())
			{
				var userId = HttpContext.GetUserId();
				var res = _cartService.RemoveOrDecreaseProduct(userId, productId);
				_logService.UserLog(res,userId, "Cart.RemoveOrDecreaseProduct",productId);
                return res;
			}

            HttpContext.RemoveOrDecreaseInCart(productId);
            return Result.Success();

        }

		[HttpGet]
		public ActionResult<int> ProductCount()
        {
            if (HttpContext.IsUserAuthenticated())
			{
				var userId = HttpContext.GetUserId();
				return _cartService.GetBasketProductCount(userId);
			}
            return HttpContext.GetCart().Count;

        }
		[HttpGet]
		public ActionResult<List<Cart>> List()
        {
            if (HttpContext.IsUserAuthenticated())
			{
				var userId = HttpContext.GetUserId();
				return _cartService.ListBasketProducts(userId);
			}
            return HttpContext.GetDbCartEntity(-1).ToList();
        }
		[HttpPost]
		public ActionResult<Result> Clear()
        {

            if (HttpContext.IsUserAuthenticated())
			{
				var userId = HttpContext.GetUserId();
				var res = _cartService.Clear(userId);
				_logService.UserLog(res,userId,"Cart.Clear");
				return res;
			}
            HttpContext.ClearCart();
            return Result.Success();

        }

	}
}
