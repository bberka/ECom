using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services;
using ECom.Domain.Abstract.Services.Base;
using ECom.Shared.DTOs;

namespace ECom.WebApi.Endpoints.ProductEndpoints.CommentEndpoints;

[Authorize]
[EndpointRoute(typeof(Add))]
public class Add : EndpointBaseSync.WithRequest<AddProductCommentRequest>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IProductService _productService;

  public Add(
    IProductService productService,
    ILogService logService) {
    _productService = productService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(Add), "Adds product comment")]
  public override CustomResult Handle(AddProductCommentRequest request) {
    var authId = HttpContext.GetUserId();
    var res = _productService.AddProductComment(authId, request);
    _logService.UserLog(res.ToResult(), authId, "ProductComment.Add", request.ToJsonString());
    return res;
  }
}