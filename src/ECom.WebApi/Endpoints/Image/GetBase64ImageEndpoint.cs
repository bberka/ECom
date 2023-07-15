namespace ECom.WebApi.Endpoints.Image;

[AllowAnonymous]
[EndpointRoute(typeof(GetBase64ImageEndpoint))]
public class GetBase64ImageEndpoint : EndpointBaseSync.WithRequest<int>.WithResult<string>
{
  private readonly IImageService _imageService;

  public GetBase64ImageEndpoint(IImageService imageService) {
    _imageService = imageService;
  }
  [HttpGet]
  [ResponseCache(Duration = 120, VaryByQueryKeys = new[] { "id" })]
  [EndpointSwaggerOperation(typeof(GetBase64ImageEndpoint), "Gets image base 64 string")]
  public override string Handle(int id) {
    return _imageService.GetImageBase64String(id);
  }
}