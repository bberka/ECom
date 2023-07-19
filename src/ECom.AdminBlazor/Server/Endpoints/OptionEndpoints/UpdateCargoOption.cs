using ECom.Domain.Entities;

namespace ECom.AdminBlazor.Server.Endpoints.OptionEndpoints;

[EndpointRoute(typeof(UpdateCargoOption))]
public class UpdateCargoOption : EndpointBaseSync.WithRequest<CargoOption>.WithResult<CustomResult>
{
  private readonly IOptionService _optionService;

  public UpdateCargoOption(IOptionService optionService) {
    _optionService = optionService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.CargoOptionUpdate)]
  [EndpointSwaggerOperation(typeof(UpdateCargoOption), "Updates cargo option")]
  public override CustomResult Handle(CargoOption request) {
    var res = _optionService.UpdateCargoOption(request);
    return res;
  }
}