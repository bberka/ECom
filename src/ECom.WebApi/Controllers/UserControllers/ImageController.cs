using ECom.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    [AllowAnonymous]
    public class ImageController : BaseUserController
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            this._imageService = imageService;
        }
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public ActionResult<string> Get(int id)
        {
            return _imageService.GetImageBase64String(id);
        }
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public ActionResult<Image?> GetImage(int id)
        {
            return _imageService.GetImage(id);
        }

    }
}
