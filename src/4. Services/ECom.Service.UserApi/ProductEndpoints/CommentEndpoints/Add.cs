namespace ECom.Service.UserApi.ProductEndpoints.CommentEndpoints;

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
  [EndpointSwaggerOperation("User_Product_Comment")]
  public override Result Handle(Request_ProductComment_Add request) {
    var authId = HttpContext.GetUserId();
    var res = _productService.AddProductComment(authId, request);
    _logService.UserLog(UserActionType.AddProductComment, res, authId, request.ToJsonString());
    return res;
  }
}