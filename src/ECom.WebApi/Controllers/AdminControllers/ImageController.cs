namespace ECom.WebApi.Controllers.AdminControllers;

public class ImageController : BaseAdminController
{
  private readonly IImageService _imageService;

  public ImageController(IImageService imageService) {
    _imageService = imageService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.Image_Upload)]
  public ActionResult<ResultData<int>> UploadImage(IFormFile file) {
    if (file is null) return BadRequest();
    var res = _imageService.UploadImage(file);
    return res.ToActionResult();
  }
}