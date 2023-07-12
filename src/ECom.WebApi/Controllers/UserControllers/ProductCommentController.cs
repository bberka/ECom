using ECom.Domain.DTOs.ProductDTOs;

namespace ECom.WebApi.Controllers.UserControllers;

public class ProductCommentController : BaseUserController
{
  private readonly ILogService _logService;
  private readonly IProductService _productService;

  public ProductCommentController(
    IProductService productService,
    ILogService logService) {
    _productService = productService;
    _logService = logService;
  }

  [HttpPost]
  public ActionResult<ResultData<int>> Add([FromBody] AddProductCommentRequest requestModel) {
    var res = _productService.AddComment(requestModel);
    _logService.UserLog(res.ToResult(), requestModel.AuthenticatedUserId, "ProductComment.Add",
      requestModel.ToJsonString());
    return res.ToActionResult();
  }
}