namespace ECom.Service.PublicApi.Controllers;

public class ProductCommentController : PublicControllerBase
{
  [FromServices]
  public IProductService ProductService { get; set; }

  [AllowAnonymous]
  [Endpoint("/product/comment/list", HttpMethodType.GET)]
  public List<ProductComment> List(Request_PageWithId request) {
    return ProductService.GetProductComments(request.Id, request.Page);
  }
}