namespace ECom.AdminApi.Endpoints.OptionEndpoints;

[EndpointRoute(typeof(GetSmtpInfo))]
public class GetSmtpInfo : EndpointBaseSync.WithoutRequest.WithResult<List<SmtpOption>>
{
  private readonly IOptionService _optionService;

  public GetSmtpInfo(IOptionService optionService)
  {
    _optionService = optionService;
  }
  [HttpGet]
  [RequirePermission(AdminOperationType.SmtpOptionGet)]
  [EndpointSwaggerOperation(typeof(GetSmtpInfo),"Gets smtp info list")]
  public override List<SmtpOption> Handle()
  {
    return _optionService.ListSmtpOptions();
  }
}