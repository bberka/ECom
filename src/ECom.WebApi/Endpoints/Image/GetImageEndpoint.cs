namespace ECom.WebApi.Endpoints.Image;

[AllowAnonymous]
[EndpointRoute(typeof(GetImageEndpoint))]
public class GetImageEndpoint : EndpointBaseSync.WithRequest<int>.WithResult<ResultData<Domain.Entities.Image>>
{
  private readonly IImageService _imageService;

  public GetImageEndpoint(IImageService imageService) {
    _imageService = imageService;
  }
  [HttpGet]
  [ResponseCache(Duration = 120, VaryByQueryKeys = new[] { "id" })]
  [EndpointSwaggerOperation(typeof(GetImageEndpoint), "Gets image")]
  public override ResultData<Domain.Entities.Image> Handle(int id) {
    return _imageService.GetImage(id);
  }
}