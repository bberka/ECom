using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;
using ECom.Shared.DTOs;

namespace ECom.WebApi.Endpoints.ProductEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(List))]
public class List : EndpointBaseSync.WithRequest<PageRequestWithCulture>.WithResult<List<Product>>
{
  private readonly IProductService _productService;

  public List(IProductService productService) {
    _productService = productService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(List), "Gets products")]
  public override List<Product> Handle(PageRequestWithCulture request) {
    return _productService.GetProducts(request.Page, request.Culture);
  }
}