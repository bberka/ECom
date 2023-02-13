using ECom.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
namespace ECom.WebApi.Controllers.UserControllers
{
    [AllowAnonymous]
    public class ProductController : BaseUserController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        //[HttpGet]
        //public ActionResult<List<Product>> ListRecommended(int page,string? culture = ConstantMgr.DefaultCulture)
        //{
        //    return new List<Product>();
        //}

        [HttpGet]
        public ActionResult<List<Product>> List(ushort page, string? culture = ConstantMgr.DefaultCulture)
        {
            return _productService.GetProducts(page, culture);
        }

        [HttpGet]
        public ActionResult<List<ProductComment>> GetComments(int productId, ushort page)
        {
            return _productService.GetProductComments(productId, page);
        }
        //[HttpGet]
        //public ActionResult<List<Product>> Search(string keyword, string? culture = ConstantMgr.DefaultCulture)
        //{
        //    return new List<Product>();
        //}
        //[HttpGet]
        //public ActionResult<List<Product>> SearchByProductCode(string code, string? culture = ConstantMgr.DefaultCulture)
        //{
        //    return new List<Product>();
        //}
        //[HttpGet]
        //public ActionResult<List<Product>> ListByCategory(int category, int page, string? culture = ConstantMgr.DefaultCulture)
        //{
        //    return new List<Product>();
        //}
        //[HttpGet]
        //public ActionResult<List<Product>> ListBySubCategory(int subCategory, int page, string? culture = ConstantMgr.DefaultCulture)
        //{
        //    return new List<Product>();
        //}
    }
}
