using ECom.Domain.DTOs.ProductDTOs;

namespace ECom.WebApi.Endpoints.Product.Comment;

[AllowAnonymous]
[EndpointRoute(typeof(ListCommentEndpoint))]
public class ListCommentEndpoint : EndpointBaseSync.WithRequest<PageRequestWithId>.WithResult<List<ProductComment>>
{
  private readonly IProductService _productService;

  public ListCommentEndpoint(IProductService productService) {
    _productService = productService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(ListCommentEndpoint),"Gets product comments")]
  public override List<ProductComment> Handle(PageRequestWithId request) {
    return _productService.GetProductComments(request.Id, request.Page);
  }
}