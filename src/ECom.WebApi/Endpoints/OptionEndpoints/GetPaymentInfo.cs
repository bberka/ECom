using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.OptionEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetPaymentInfo))]
public class GetPaymentInfo : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.PaymentOption>>
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