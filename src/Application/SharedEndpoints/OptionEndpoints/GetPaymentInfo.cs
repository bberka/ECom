using ECom.Domain.Entities;

namespace ECom.Application.SharedEndpoints.OptionEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetPaymentInfo))]
public class GetPaymentInfo : EndpointBaseSync.WithoutRequest.WithResult<List<PaymentOption>>
{
  private readonly IOptionService _optionService;

  public GetPaymentInfo(IOptionService optionService) {
    _optionService = optionService;
  }

  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetPaymentInfo), "Gets payment information")]
  public override List<PaymentOption> Handle() {
    return _optionService.ListPaymentOptions();
  }
}