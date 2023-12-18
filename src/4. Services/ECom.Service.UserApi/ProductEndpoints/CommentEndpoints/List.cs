namespace ECom.Service.UserApi.ProductEndpoints.CommentEndpoints;

public class List : EndpointBaseSync.WithRequest<Request_PageWithId>.WithResult<List<ProductComment>>
{
  private readonly IProductService _productService;

  public List(IProductService productService) {
    _productService = productService;
  }

  [AllowAnonymous]
  [Endpoint("/user/product/comment/list", HttpMethodType.GET)]
  [EndpointSwaggerOperation("User_Product_Comment")]
  public override List<ProductComment> Handle(Request_PageWithId request) {
    return _productService.GetProductComments(request.Id, request.Page);
  }
}