namespace ECom.WebApi.Endpoints.Product;

[AllowAnonymous]
[EndpointRoute(typeof(ListProductEndpoint))]
public class ListProductEndpoint : EndpointBaseSync.WithRequest<PageRequestWithCulture>.WithResult<List<Domain.Entities.Product>>
{
  private readonly IProductService _productService;

  public ListProductEndpoint(IProductService productService) {
    _productService = productService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(ListProductEndpoint),"Gets products")]
  public override List<Domain.Entities.Product> Handle(PageRequestWithCulture request) {
    return _productService.GetProducts(request.Page, request.Culture);
  }
}