using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
using ECom.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{
    public class ImageController : BaseAdminController
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            this._imageService = imageService;
        }
        [HttpPost]
        [ResponseCache(Duration = 60)]
        [EndPointAuthorizationFilter(AdminOperationType.Image_Upload)]
        public ActionResult<ResultData<int>> UploadImage(IFormFile file)
        {
            if (file is null) return BadRequest();
            var res = _imageService.UploadImage(file);
            return res;
        }


	}
}
