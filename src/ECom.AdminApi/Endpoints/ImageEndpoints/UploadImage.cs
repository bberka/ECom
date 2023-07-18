namespace ECom.AdminApi.Endpoints.ImageEndpoints;


[EndpointRoute(typeof(UploadImage))]
public class UploadImage : EndpointBaseSync.WithRequest<IFormFile>.WithResult<CustomResult<int>>
{
  private readonly IImageService _imageService;

  public UploadImage(IImageService imageService) {
    _imageService = imageService;
  }
  [HttpPost]
  [RequirePermission(AdminOperationType.ImageUpload)]
  [EndpointSwaggerOperation(typeof(UploadImage),"Upload image")]
  public override CustomResult<int> Handle(IFormFile file)
  {
    if (file is null) throw new InvalidOperationException("Image IFormFile can not be null");
    var res = _imageService.UploadImage(file);
    return res;
  }
}