namespace ECom.WebApi.Controllers.AdminControllers;

public class ProductController : BaseAdminController
{
  private readonly ILogService _logService;
  private readonly IProductService _productService;

  public ProductController(
    IProductService productService,
    ILogService logService) {
    _productService = productService;
    _logService = logService;
  }
}