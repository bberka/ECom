﻿using ECom.Application.Attributes;
using ECom.Domain.DTOs.ProductDto;

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
  [EndpointSwaggerOperation(typeof(Add),"Adds product comment")]
  public override CustomResult Handle(AddProductCommentRequest request) {
    var res = _productService.AddProductComment(request);
    _logService.UserLog(res.ToResult(), request.AuthenticatedUserId, "ProductComment.Add",request.ToJsonString());
    return res;
  }

}