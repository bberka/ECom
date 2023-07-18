﻿using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.ProductEndpoints.CommentEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(List))]
public class List : EndpointBaseSync.WithRequest<PageRequestWithId>.WithResult<List<ProductComment>>
{
  private readonly IProductService _productService;

  public List(IProductService productService) {
    _productService = productService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(List),"Gets product comments")]
  public override List<ProductComment> Handle(PageRequestWithId request) {
    return _productService.GetProductComments(request.Id, request.Page);
  }
}