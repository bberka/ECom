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
        public ActionResult<ResultData<int>> Add([FromBody] AddProductCommentRequestModel requestModel)
        {
            var res = _productService.AddComment(requestModel);
            _logService.UserLog(res.ToResult(),requestModel.AuthenticatedUserId,"ProductComment.Add",requestModel.ToJsonString());
            return res.WithoutRv();
        }
        //[HttpPost]
        //public ActionResult<ResultData<int>> UploadCommentImage([FromBody] IFormFile file, [FromQuery] int commentId)
        //{
        //    var userId = HttpContext.GetUserId();
        //    var res = _productService.AddCommentImage(file, userId,commentId);
        //    _logService.UserLog(res.ToResult(),userId,"ProductCommentImage.Add");
        //    return res.WithoutRv();
        //}

    }
}
