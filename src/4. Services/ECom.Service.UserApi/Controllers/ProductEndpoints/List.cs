namespace ECom.Service.UserApi.Controllers.ProductEndpoints;

public class List : EndpointBaseSync.WithRequest<Request_PageWithCulture>.WithResult<List<Product>>
{
  private readonly IProductService _productService;

  public List(IProductService productService) {
    _productService = productService;
  }

  [AllowAnonymous]
  [Endpoint("/user/products", HttpMethodType.POST)]
  [OpenApiOperation("Product")]
  [OpenApiTag(UserServiceResolver.DocName)]
  public override List<Product> Handle(Request_PageWithCulture request) {
    return _productService.GetProducts(request.Page, request.Culture);
  }
}