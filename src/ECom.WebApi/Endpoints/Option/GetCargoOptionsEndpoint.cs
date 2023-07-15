namespace ECom.WebApi.Endpoints.Option;

[AllowAnonymous]
[EndpointRoute(typeof(GetCargoOptionsEndpoint))]
public class GetCargoOptionsEndpoint : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.CargoOption>>
{
  private readonly IOptionService _optionService;

  public GetCargoOptionsEndpoint(IOptionService optionService) {
    _optionService = optionService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetCargoOptionsEndpoint), "Get all cargo options")]
  public override List<CargoOption> Handle() {
    return _optionService.ListCargoOptions();
  }
}