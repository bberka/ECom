using ECom.Service.UserApi.Attributes;

namespace ECom.Service.UserApi.Controllers.ProductEndpoints.CommentEndpoints;

public class Add : EndpointBaseSync.WithRequest<Request_ProductComment_Add>.WithResult<Result>
{
  private readonly ILogService _logService;
  private readonly IProductService _productService;

  public Add(
    IProductService productService,
    ILogService logService) {
    _productService = productService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/product/comment/add", HttpMethodType.POST)]
  [OpenApiOperation("Product_Comment")]
  [OpenApiTag(UserServiceResolver.DocName)]
  public override Result Handle(Request_ProductComment_Add request) {
    var authId = HttpContext.GetUserId();
    var res = _productService.AddProductComment(authId, request);
    _logService.UserLog(UserActionType.AddProductComment, res, authId, request.ToJsonString());
    return res;
  }
}