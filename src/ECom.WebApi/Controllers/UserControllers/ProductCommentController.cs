using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers.UserControllers
{
    public class ProductCommentController : BaseUserController
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly ILogService _logService;

        public ProductCommentController(
            IProductService productService,
            IImageService imageService,
            ILogService logService)
        {
            _productService = productService;
            _imageService = imageService;
            _logService = logService;
        }

        [HttpPost]
        public ActionResult<ResultData<int>> Add([FromBody] AddProductCommentRequestModel requestModel)
        {
            var res = _productService.AddComment(requestModel);
            _logService.UserLog(res.ToResult(),requestModel.AuthenticatedUserId,"ProductComment.Add",requestModel.ToJsonString());
            return res.WithoutRv();
        }
        [HttpPost]
        public ActionResult<ResultData<int>> UploadImage(IFormFile file)
        {
            var res = _imageService.UploadImage(file);
            return res.WithoutRv();
        }

    }
}
