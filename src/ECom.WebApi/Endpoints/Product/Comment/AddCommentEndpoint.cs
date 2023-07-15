using System.CodeDom;
using ECom.Domain.DTOs.ProductDTOs;

namespace ECom.WebApi.Endpoints.Product.Comment;

[Authorize]
[EndpointRoute(typeof(AddCommentEndpoint))]
public class AddCommentEndpoint : EndpointBaseSync.WithRequest<AddProductCommentRequest>.WithResult<Result>
{
  
  private readonly ILogService _logService;
  private readonly IProductService _productService;

  public AddCommentEndpoint(
    IProductService productService,
    ILogService logService) {
    _productService = productService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(AddCommentEndpoint),"Adds product comment")]
  public override Result Handle(AddProductCommentRequest request) {
    var res = _productService.AddComment(request);
    _logService.UserLog(res.ToResult(), request.AuthenticatedUserId, "ProductComment.Add",request.ToJsonString());
    return res;
  }

}