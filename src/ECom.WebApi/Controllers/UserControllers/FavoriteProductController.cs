using ECom.Domain.ApiModels.Response;
using ECom.Domain.Constants;
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
        public ActionResult<List<FavoriteProduct>> List(ushort page,string culture = ConstantMgr.DefaultCulture)
        {
            var userId = HttpContext.GetUserId();
            return _favoriteProductService.GetFavoriteProducts(userId, page ,culture);
        }
        [HttpPost]
        public ActionResult<Result> Add([FromBody] int productId)
        {
            var userId = HttpContext.GetUserId();
            return _favoriteProductService.AddProduct(userId, productId);
        }
        [HttpPost]
        public ActionResult<Result> Remove([FromBody] int productId)
        {
            var userId = HttpContext.GetUserId();
            return _favoriteProductService.RemoveProduct(userId, productId);
        }
    }
}
