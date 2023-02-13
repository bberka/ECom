using System.Net;
using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers.UserControllers
{
    public class ProductCommentController : BaseUserController
    {
        private readonly IProductService _productService;
        private readonly ILogService _logService;

        public ProductCommentController(
            IProductService productService,
            ILogService logService)
        {
            _productService = productService;
            _logService = logService;
        }

        [HttpPost]
        public ActionResult<ResultData<int>> Add([FromBody] AddProductCommentRequest requestModel)
        {
            var res = _productService.AddComment(requestModel);
            _logService.UserLog(res.ToResult(),requestModel.AuthenticatedUserId,"ProductComment.Add",requestModel.ToJsonString());
            return res.WithoutRv();
        }
    
    }
}
