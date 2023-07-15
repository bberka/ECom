namespace ECom.WebApi.Endpoints.Option;

[AllowAnonymous]
[EndpointRoute(typeof(GetPaymentOptionsEndpoint))]
public class GetPaymentOptionsEndpoint : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.PaymentOption>>
{
  private readonly IOptionService _optionService;

  public GetPaymentOptionsEndpoint(IOptionService optionService) {
    _optionService = optionService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetPaymentOptionsEndpoint), "Get all payment options")]
  public override List<PaymentOption> Handle() {
    return _optionService.ListPaymentOptions();

  }
}