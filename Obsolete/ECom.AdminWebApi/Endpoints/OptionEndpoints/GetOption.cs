using ECom.Domain.Entities;

namespace ECom.AdminWebApi.Endpoints.OptionEndpoints;

[EndpointRoute(typeof(GetOption))]
public class GetOption : EndpointBaseSync.WithoutRequest.WithResult<Option>
{
  private readonly IOptionService _optionService;

  public GetOption(IOptionService optionService) {
    _optionService = optionService;
  }

  [HttpGet]
  [RequirePermission(AdminPermission.ManageGeneralOptions)]
  [EndpointSwaggerOperation(typeof(GetOption), "Gets base option")]
  public override Option Handle() {
    return _optionService.GetOption();
  }
}