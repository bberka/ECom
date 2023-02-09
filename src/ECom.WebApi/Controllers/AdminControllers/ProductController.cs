using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{

    public class ProductController : BaseAdminController
    {
        private readonly IProductService _productService;
        private readonly ILogService _logService;

        public ProductController(
            IProductService productService,
            ILogService logService)
        {
            _productService = productService;
            _logService = logService;
        }
    }
}
