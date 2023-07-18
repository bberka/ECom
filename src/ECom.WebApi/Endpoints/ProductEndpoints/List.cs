using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.ProductEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(List))]
public class List : EndpointBaseSync.WithRequest<PageRequestWithCulture>.WithResult<List<Domain.Entities.Product>>
{
  private readonly IProductService _productService;

  public List(IProductService productService) {
    _productService = productService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(List),"Gets products")]
  public override List<Domain.Entities.Product> Handle(PageRequestWithCulture request) {
    return _productService.GetProducts(request.Page, request.Culture);
  }
}