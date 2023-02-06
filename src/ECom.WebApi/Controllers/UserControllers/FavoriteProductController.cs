using ECom.Domain.ApiModels.Response;
using Microsoft.AspNetCore.Authorization;
namespace ECom.WebApi.Controllers.UserControllers
{
    public class FavoriteProductController : BaseUserController
    {
        private readonly IFavoriteProductService _favoriteProductService;

        public FavoriteProductController(IFavoriteProductService favoriteProductService)
        {
            this._favoriteProductService = favoriteProductService;
        }
        [HttpGet]
        public ActionResult<List<ProductDTO>> List()
        {
            var userId = HttpContext.GetUserId();
            return _favoriteProductService.GetFavoriteProducts(userId);
        }
        [HttpPost]
        public ActionResult<Result> Add(int productId)
        {
            var userId = HttpContext.GetUserId();
            return _favoriteProductService.AddProduct(userId, productId);
        }
        [HttpPost]
        public ActionResult<Result> Remove(int productId)
        {
            var userId = HttpContext.GetUserId();
            return _favoriteProductService.RemoveProduct(userId, productId);
        }
    }
}
