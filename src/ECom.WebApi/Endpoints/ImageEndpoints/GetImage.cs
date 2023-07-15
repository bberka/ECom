using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.ImageEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetImage))]
public class GetImage : EndpointBaseSync.WithRequest<int>.WithResult<ResultData<Domain.Entities.Image>>
{
  private readonly IImageService _imageService;

  public GetImage(IImageService imageService) {
    _imageService = imageService;
  }
  [HttpGet]
  [ResponseCache(Duration = 120, VaryByQueryKeys = new[] { "id" })]
  [EndpointSwaggerOperation(typeof(GetImage), "Gets image")]
  public override ResultData<Domain.Entities.Image> Handle(int id) {
    return _imageService.GetImage(id);
  }
}