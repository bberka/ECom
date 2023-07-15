using ECom.Domain.Lib;

namespace ECom.WebApi.Endpoints.Option;

[AllowAnonymous]
[EndpointRoute(typeof(GetCurrenciesEndpoint))]
public class GetCurrenciesEndpoint : EndpointBaseSync.WithoutRequest.WithResult<string[]>
{
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetCurrenciesEndpoint), "Get all currency types")]
  public override string[] Handle() {
    return CommonLib.GetCurrencyTypes();

  }
}