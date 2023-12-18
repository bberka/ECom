namespace ECom.Service.UserApi.Controllers;

[AuthorizeUserOnly]
public class ProductCommentController : UserControllerBase
{
  [FromServices]
  public IProductService ProductService { get; set; }

  [Endpoint("/user/product/comment/add", HttpMethodType.POST)]
  public Result Add(Request_ProductComment_Add request) {
    var authId = HttpContext.GetUserId();
    var res = ProductService.AddProductComment(authId, request);
    LogService.UserLog(UserActionType.AddProductComment, res, authId, request.ToJsonString());
    return res;
  }
}