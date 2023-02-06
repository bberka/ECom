using ECom.Domain.ApiModels.Response;
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
        [HttpGet]
        public ActionResult<List<ProductDTO>> ListRecommended(int page,string? culture = "tr")
        {
            return new List<ProductDTO>();
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> List(int page, string? culture = "tr")
        {
            return new List<ProductDTO>();
        }
        [HttpGet]
        public ActionResult<List<ProductDTO>> Search(string keyword, string? culture = "tr")
        {
            return new List<ProductDTO>();
        }
        [HttpGet]
        public ActionResult<List<ProductDTO>> SearchByProductCode(string code, string? culture = "tr")
        {
            return new List<ProductDTO>();
        }
        [HttpGet]
        public ActionResult<List<ProductDTO>> ListByCategory(int category, int page, string? culture = "tr")
        {
            return new List<ProductDTO>();
        }
        [HttpGet]
        public ActionResult<List<ProductDTO>> ListBySubCategory(int subCategory, int page, string? culture = "tr")
        {
            return new List<ProductDTO>();
        }
    }
}
