namespace ECom.Application.SharedEndpoints.OptionEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetCargoInfo))]
public class GetCargoInfo : EndpointBaseSync.WithoutRequest.WithResult<List<CargoOption>>
{
    private readonly IOptionService _optionService;

    public GetCargoInfo(IOptionService optionService)
    {
        _optionService = optionService;
    }
    [HttpGet]
    [EndpointSwaggerOperation(typeof(GetCargoInfo), "Get all cargo information")]
    public override List<CargoOption> Handle()
    {
        return _optionService.ListCargoOptions();
    }
}