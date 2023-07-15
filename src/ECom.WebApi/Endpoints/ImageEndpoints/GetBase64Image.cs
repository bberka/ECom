using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.ImageEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetBase64Image))]
public class GetBase64Image : EndpointBaseSync.WithRequest<int>.WithResult<string>
{
  private readonly IImageService _imageService;

  public GetBase64Image(IImageService imageService) {
    _imageService = imageService;
  }
  [HttpGet]
  [ResponseCache(Duration = 120, VaryByQueryKeys = new[] { "id" })]
  [EndpointSwaggerOperation(typeof(GetBase64Image), "Gets image base 64 string")]
  public override string Handle(int id) {
    return _imageService.GetImageBase64String(id);
  }
}