using ECom.Domain.ApiModels.Response;
using ECom.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
namespace ECom.WebApi.Controllers.UserControllers
{
    public class FavoriteProductController : BaseUserController
    {
        private readonly IFavoriteProductService _favoriteProductService;
        private readonly ILogService _logService;

        public FavoriteProductController(
            IFavoriteProductService favoriteProductService,
            ILogService logService)
        {
            this._favoriteProductService = favoriteProductService;
            _logService = logService;
        }
        [HttpGet]
        public ActionResult<List<FavoriteProduct>> List(ushort page,string culture = ConstantMgr.DefaultCulture)
        {
            var userId = HttpContext.GetUserId();
            var res = _favoriteProductService.GetFavoriteProducts(userId, page ,culture);
            return res;
        }


        [HttpPost]
        public ActionResult<Result> Add([FromBody] int productId)
        {
            var userId = HttpContext.GetUserId();
            var res = _favoriteProductService.AddProduct(userId, productId);
            _logService.UserLog(res,userId,"FavoriteProduct.Add",productId);
            return res.WithoutRv();
        }
        [HttpPost]
        public ActionResult<Result> Remove([FromBody] int productId)
        {
            var userId = HttpContext.GetUserId();
            var res = _favoriteProductService.RemoveProduct(userId, productId);
            _logService.UserLog(res,userId,"FavoriteProduct.Remove",productId);
            return res.WithoutRv();

        }
    }
}
