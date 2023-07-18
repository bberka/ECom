namespace ECom.Application.SharedEndpoints.ImageEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetImage))]
public class GetImage : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult<Domain.Entities.Image>>
{
  private readonly IImageService _imageService;

  public GetImage(IImageService imageService) {
    _imageService = imageService;
  }
  [HttpGet]
  [ResponseCache(Duration = 120, VaryByQueryKeys = new[] { "id" })]
  [EndpointSwaggerOperation(typeof(GetImage), "Gets image")]
  public override CustomResult<Domain.Entities.Image> Handle(int id) {
    return _imageService.GetImage(id);
  }
}