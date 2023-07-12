using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers.UserControllers;

[AllowAnonymous]
public class ImageController : BaseUserController
{
  private readonly IImageService _imageService;

  public ImageController(IImageService imageService) {
    _imageService = imageService;
  }

  [HttpGet]
  [ResponseCache(Duration = 120, VaryByQueryKeys = new[] { "id" })]
  public ActionResult<string> Get(int id) {
    return _imageService.GetImageBase64String(id);
  }

  [HttpGet]
  [ResponseCache(Duration = 120, VaryByQueryKeys = new[] { "id" })]
  public ActionResult<ResultData<Image>> GetImage(int id) {
    return _imageService.GetImage(id).ToActionResult();
  }
}