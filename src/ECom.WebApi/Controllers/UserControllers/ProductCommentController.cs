namespace ECom.WebApi.Controllers.UserControllers
{

    public class ProductCommentController : BaseUserController
    {
        private readonly IProductService _productService;

        public ProductCommentController(IProductService productService)
        {
            _productService = productService;
        }
    }
}
