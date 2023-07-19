using ECom.Domain.Entities;

namespace ECom.AdminBlazor.Server.Endpoints.OptionEndpoints;

[EndpointRoute(typeof(UpdateSmtpOption))]
public class UpdateSmtpOption : EndpointBaseSync.WithRequest<SmtpOption>.WithResult<CustomResult>
{
  private readonly IOptionService _optionService;

  public UpdateSmtpOption(IOptionService optionService) {
    _optionService = optionService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.SmtpOptionUpdate)]
  [EndpointSwaggerOperation(typeof(UpdateSmtpOption), "Updates smtp option")]
  public override CustomResult Handle(SmtpOption request) {
    var res = _optionService.UpdateSmtpOption(request);
    return res;
  }
}