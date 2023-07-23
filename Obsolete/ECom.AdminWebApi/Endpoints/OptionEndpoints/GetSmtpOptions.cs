using ECom.Domain.Entities;

namespace ECom.AdminWebApi.Endpoints.OptionEndpoints;

[EndpointRoute(typeof(GetSmtpOptions))]
public class GetSmtpOptions : EndpointBaseSync.WithoutRequest.WithResult<List<SmtpOption>>
{
  private readonly IOptionService _optionService;

  public GetSmtpOptions(IOptionService optionService) {
    _optionService = optionService;
  }

  [HttpGet]
  [RequirePermission(AdminPermission.ManageSmtpOption)]
  [EndpointSwaggerOperation(typeof(GetSmtpOptions), "Gets smtp info list")]
  public override List<SmtpOption> Handle() {
    return _optionService.ListSmtpOptions();
  }
}