namespace ECom.Application.SharedEndpoints.OptionEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetCurrencies))]
public class GetCurrencies : EndpointBaseSync.WithoutRequest.WithResult<string[]>
{
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetCurrencies), "Packs all currency types")]
  public override string[] Handle() {
    return CommonLib.GetCurrencyTypes();
  }
}