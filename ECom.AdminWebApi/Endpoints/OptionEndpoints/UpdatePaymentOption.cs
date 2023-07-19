using ECom.Domain.Entities;

namespace ECom.AdminWebApi.Endpoints.OptionEndpoints;

[EndpointRoute(typeof(UpdatePaymentOption))]
public class UpdatePaymentOption : EndpointBaseSync.WithRequest<PaymentOption>.WithResult<CustomResult>
{
  private readonly IOptionService _optionService;

  public UpdatePaymentOption(IOptionService optionService) {
    _optionService = optionService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.PaymentOptionUpdate)]
  [EndpointSwaggerOperation(typeof(UpdatePaymentOption), "Updates payment information")]
  public override CustomResult Handle(PaymentOption request) {
    var res = _optionService.UpdatePaymentOption(request);
    return res;
  }
}